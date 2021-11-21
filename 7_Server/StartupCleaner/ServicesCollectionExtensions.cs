using Blazored.LocalStorage;
using illegible.DataStructure.IdentityDataContextDefine;
using illegible.Kernel.Constants;
using illegible.Repository.IRepository.BlogPostTablesIRepository;
using illegible.Repository.Repository.BlogPostRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace illegible.Server.StartupCleaner
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddConventionalService(
           this IServiceCollection services)
        {
            #region Repoes

            services.AddScoped<IBlogPostRepository, BlogPostRepository>();

            #endregion

            #region Session

            services.AddSession();

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

            return services;
        }
    }
}
