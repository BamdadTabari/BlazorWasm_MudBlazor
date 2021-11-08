using illegible.Repository.IRepository.BlogPostTablesIRepository;
using illegible.Repository.Repository.BlogPostRepository;
using illegible.Server.StartupCleaner;
using illegible.Shared.SharedServices.IService;
using illegible.Shared.SharedServices.Service;
using Mapster;
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
                app.UseHsts();
            }

            // use elmah.io for error tracking
            app.UseElmahIo();

            //Registered before static files to always set header
            #region NWebSec Configs Part 1

            app.UseXContentTypeOptions();
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

            app.UseHsts(hsts => hsts.MaxAge(365)); // for https 
            app.UseXfo(xfo => xfo.Deny());
            //Register this earlier if there's middleware that might redirect.
            // this baby validate redirects => sample post for understanding invalid redirection: https://www.troyhunt.com/owasp-top-10-for-net-developers-part-10/
            app.UseRedirectValidation(opts =>
            {
                //tip : for Allow redirects to custom HTTPS port use this (4430 is an example for custom port)=>
                //opts.AllowSameHostRedirectsToHttps(4430); 

                // this method allows redirections to https
                opts.AllowSameHostRedirectsToHttps();
                // this method create a white list for valid sites to redirect 
                opts.AllowedDestinations("http://www.GitHub.com/", "https://www.google.com/");
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
