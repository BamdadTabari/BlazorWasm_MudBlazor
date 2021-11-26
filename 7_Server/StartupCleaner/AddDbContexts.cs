using illegible.DataStructure.DataContextDefine;
using illegible.DataStructure.IdentityDataContextDefine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace illegible.Server.StartupCleaner
{
    public static class AddDbContexts
    {
        public static IServiceCollection AddDbContextsService(
            this IServiceCollection services
            , IConfiguration configuration)
        {
            // this code define my normal data context
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("IllegibleConnection"));
            });

            //this code define my identity data context
            services.AddDbContext<IdentityDataContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("IllegibleIdentityConnection"));
            });

            return services;
        }
    }
}
