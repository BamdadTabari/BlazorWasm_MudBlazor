using Blazored.LocalStorage;
using illegible.Shared.SharedInfrastructure;
using illegible.Shared.SharedServices.IService;
using illegible.Shared.SharedServices.Service;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace illegible.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp =>
            new HttpClient 
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
            });

            //JWT Authentication
            builder.Services.AddAuthorizationCore();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<AuthenticationStateProvider,
                ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<IHttpRequestHandlerService, HttpRequestHandlerService>();


            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

            // register the Telerik services
            builder.Services.AddTelerikBlazor();


            await builder.Build().RunAsync();
        }
    }
}
