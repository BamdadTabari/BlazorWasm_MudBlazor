using illegible.Shared.SharedDTO.BlogPost;
using illegible.Shared.SharedServices.IService;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace illegible.Shared.SharedServices.Service
{
    public class HttpRequestHandlerService : IHttpRequestHandlerService
    {
        private HttpClient _httpClient;
        public HttpRequestHandlerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// this method get any dto Type and by uriAddress connect to related api action
        /// so it can get data as same Dto Type
        /// i dont wanna handle programmer mistakes , just use elmah.io 
        /// error messages are for user , not you :D
        /// </summary>
        /// <typeparam name="TDTO">
        /// any Type of Object You wanna recive from api action
        /// it can be list of objects , or just one variable
        /// </typeparam>
        /// <param name="uriAddress">Api action address use routing attributes</param>
        /// <returns></returns>
        public async Task<TDTO> GetAsHttpAsync<TDTO>(string uriAddress)
        {
            return await _httpClient.GetFromJsonAsync<TDTO>(uriAddress);
        }

        // handle http req and automaticly convert sendig Dto to json
        /// <summary>
        /// ok with this you can post any object to any api action
        /// should use when wanna add a single line in specific table of dataBase
        /// </summary>
        /// <param name="DTO">any single object</param>
        /// <param name="uriAddress">Api action address use routing attributes</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostAsHttpJsonAsync(object DTO, string uriAddress)
        {
            return await _httpClient.PostAsJsonAsync(uriAddress, DTO);
        }


    }
}
