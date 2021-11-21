using illegible.Server.StartupCleaner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace illegible.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // this method defined in startUpCleaner and use to Define Diffrent DbContext's
            services.AddDbContextsService(Configuration);

            // this method defined in startUpCleaner
            // and use to Define Additional Services
            services.AddConventionalService();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddCors(opt =>
            {
                opt.AddPolicy("IllegibleCors", builder =>
                {
                    builder.WithOrigins("https://localhost:44345/", "http://localhost:6662")
                        .AllowAnyHeader()
                        .AllowAnyMethod().SetPreflightMaxAge(TimeSpan.FromMinutes(1));
                });
            });

        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // nWebSec Configs 
                // force browser to use https
                // tip : method docs:https://docs.nwebsec.com/en/latest/nwebsec/Configuring-hsts.html
                app.UseHsts(hsts => hsts
                    // maxAge is a TimeSpan
                    .MaxAge(365)); // https protocol between client and server
                    //shared secure key between them is valid for 365 day
            }

            app.UseCors("IllegibleCors");
            //Registered before static files to always set header
            #region NWebSec Configs Part 1
            // Content Security Policy
            // tip: read this book => https://www.w3.org/TR/2021/WD-CSP3-20210629/ to understanding what is csp
            // tip : or you just can read a simple article => https://www.html5rocks.com/en/tutorials/security/content-security-policy/
            app.UseCsp(options => options
                    // default source for any content type set to self
                    // that mean's the web site is a default member of csp white list for it self
                    .DefaultSources(s => s.Self())
                    .ConnectSources(x=>x.Self().CustomSources("ws:"))
                    // in custom sources you can see "data:" this is for styles or js file inside of libraries
                    // i use this to allow telerik.Blazor UI Fonts and Styles
                    .StyleSources(x=>x.Self().CustomSources("data:").UnsafeInline())
                    .FontSources(x=>x.Self().CustomSources("data:"))
                    // if any sources are http this method upgrade them to https
                    // just read this : https://docs.nwebsec.com/en/latest/nwebsec/Upgrade-insecure-requests.html
                    .UpgradeInsecureRequests()
                    .ScriptSources(x=>x.Self().UnsafeInline().UnsafeEval())
                    // this method block mix content as you see 
                    // it help's to avoid from injection attacks
                    .BlockAllMixedContent()
                    
                    // and here we go => set dribble as image source white list member
                    .ImageSources(s =>
                        s.Self().CustomSources("https://dribbble.com/"))
                    
                    // set media source white list
                    .MediaSources(s =>
                        s.Self().CustomSources("https://www.youtube.com/",
                            "https://www.aparat.com/"))
            );

            // tip : Referer header: privacy and security concerns : https://developer.mozilla.org/en-US/docs/Web/Security/Referer_header:_privacy_and_security_concerns#the_referrer_problem
            app.UseReferrerPolicy(opts =>
                //Send the origin, path, and querystring in Referer when the protocol security level stays the same
                //or improves(HTTP→HTTP, HTTP→HTTPS, HTTPS→HTTPS).
                //Don't send the Referer header for requests to less secure destinations (HTTPS→HTTP, HTTPS→file).
                opts.NoReferrerWhenDowngrade()
                // see more ReferrerPolicy options in :https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Referrer-Policy
                );

            #endregion

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            //Registered after static files, to set headers for dynamic content.
            #region NWebSec Configs part 2

            // cross site scripting protection 
            // tip : what is xss? => https://portswigger.net/web-security/cross-site-scripting
            app.UseXXssProtection(options => options.EnabledWithBlockMode());

            //Register this earlier if there's middleware that might redirect.
            // this baby validate redirects => sample post for understanding invalid redirection: https://www.troyhunt.com/owasp-top-10-for-net-developers-part-10/
            app.UseRedirectValidation(opts =>
            {
                //tip : for Allow redirects to custom HTTPS port use this (4430 is an example for custom port)=>
                //opts.AllowSameHostRedirectsToHttps(4430); 

                // this method allows redirections to https
                opts.AllowSameHostRedirectsToHttps();
                // this method create a white list for valid sites to redirect 
                opts.AllowedDestinations
                    ("http://www.GitHub.com/", "https://gitlab.com/", "https://www.youtube.com/", "https://stackoverflow.com/");
            });

            #endregion

            app.UseRouting();

            //Authentication && Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }

    }
}
