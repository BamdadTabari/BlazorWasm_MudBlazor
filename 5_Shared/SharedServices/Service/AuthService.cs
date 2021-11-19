using Blazored.LocalStorage;
using illegible.Shared.SharedInfrastructure;
using illegible.Shared.SharedServices.IService;
using illegible.Shared.SharedDto.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace illegible.Shared.SharedServices.Service
{
    // in this service i'm gonna Personalize Authentication
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        // i use ILocalStorageService(it's a nuget) here
        // to get or set user token's
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        // get register view model and validate it
        public async Task<RegisterResultDto> Register
            (RegisterModelDto registerModel)
        {
            // first i serialize RegisterResultDto to json
            var registerModelAsJson = JsonSerializer
                .Serialize(registerModel);

            // then i send jsonRegisterViewModel
            // to accounts api controller
            // and get the httpResponseMassage with httpClient
            // as you see i'm encoding the http request with utf8
            // for more security you can do it with utf32 or something else
            var response = await _httpClient
                .PostAsync("api/accounts",
                new StringContent(registerModelAsJson,
                Encoding.UTF8, "application/json"));

            // http response is a jsonRegisterResultDto
            // then i deserialize it to  RegisterResultDto object
            var registerResult = JsonSerializer
               .Deserialize<RegisterResultDto>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions 
                { PropertyNameCaseInsensitive = true });

            // and there we go ,
            // i return register result
            return registerResult;
        }

        // get user login data and validate it
        public async Task<LoginResultDto> Login(LoginModelDto loginModel)
        {
            // like register method i serialize loginViewModel
            // to json
            var loginAsJson = JsonSerializer.Serialize(loginModel);

            // then like register method
            // send jsonLoginDto to login controller Encoded in utf8
            //and get response
            var response = await _httpClient
                .PostAsync("Login",
                new StringContent(loginAsJson,
                Encoding.UTF8, "application/json"));
            
            // then deserialize response to LoginDto
            var loginResult = JsonSerializer.Deserialize<LoginResultDto>
                (await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            // in case of invalid authentication data send it back 
            // for showing errors
            if (!response.IsSuccessStatusCode)
            {
                return loginResult;
            }

            // as i said above i use local storage here
            // to get or set token's
            await _localStorage.SetItemAsync("authToken", loginResult.Token);

            // Mark User As Authenticated 
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);

            // set http Authorization req header with bearer scheme
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

            return loginResult;
        }

        public async Task Logout()
        {
            // remove Authentication Generated Token 
            await _localStorage.RemoveItemAsync("authToken");

            // Mark User As Logged Out
            ((ApiAuthenticationStateProvider)
                _authenticationStateProvider)
                .MarkUserAsLoggedOut();

            // remove http Authorization req header
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }


    }
}
