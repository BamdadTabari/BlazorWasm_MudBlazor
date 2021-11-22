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
            
            // this method defined in startUpCleaner and use to Define Services
            services.AddConventionalService();

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

            app.AppConfigureMethod();

            
        }

    }
}
