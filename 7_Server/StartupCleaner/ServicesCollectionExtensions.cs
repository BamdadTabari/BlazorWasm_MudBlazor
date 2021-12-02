using illegible.DataStructure.IdentityDataContextDefine;
using illegible.Kernel.Constants;
using illegible.Repository.IRepository.BlogPostTablesIRepository;
using illegible.Repository.Repository.BlogPostRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace illegible.Server.StartupCleaner
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddConventionalService(
           this IServiceCollection services)
        {

            #region Basic Services

            services.AddSession();
            services.AddControllersWithViews();
            services.AddRazorPages();
            //services.AddCors(opt =>
            //{
            //    opt.AddPolicy("IllegibleCors", builder =>
            //    {
            //        builder.WithOrigins("https://localhost:44345/", "http://localhost:6662")
            //            .AllowAnyHeader()
            //            .AllowAnyMethod().SetPreflightMaxAge(TimeSpan.FromMinutes(1));
            //    });
            //});
            #endregion

            #region IDentity with jwt

            services.AddDefaultIdentity<IdentityUser>()
                 .AddEntityFrameworkStores<IdentityDataContext>();

            // const data from kernel (read this class comments)
            var jwtSetting = new JwtSetting();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtSetting.ValidateIssuer,
                    ValidateAudience = jwtSetting.ValidateAudience,
                    ValidateLifetime = jwtSetting.ValidateLifetime,
                    ValidateIssuerSigningKey = jwtSetting.ValidateIssuerSigningKey,
                    ValidIssuer = jwtSetting.ValidIssuer,
                    ValidAudience = jwtSetting.ValidAudience,
                    IssuerSigningKey =
                    new SymmetricSecurityKey
                    (Encoding.UTF8
                    .GetBytes(jwtSetting.SecuritySignInKey)),
                };
            });

            #endregion

            #region AutoMapper

            services.AddAutoMapper(typeof(Startup));

            #endregion

            #region Autofac

            services.AddAutofac();

            #endregion

            return services;
        }
    }
    /// <summary>
    /// autoFac Containers Registration
    /// </summary>
    public static class ContainerSetup
    {
        public static void SetupContainer(ContainerBuilder builder)
        {
            builder.RegisterType<BlogPostRepository>().As<IBlogPostRepository>().InstancePerMatchingLifetimeScope();
        }
    }
}
