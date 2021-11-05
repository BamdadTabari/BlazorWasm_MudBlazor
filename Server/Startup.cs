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
            // and use to Define AditionalServices
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

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

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
