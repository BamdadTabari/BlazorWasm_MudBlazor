using illegible.Kernel.Paging;
using illegible.Kernel.RequestFeatures;
using illegible.Shared.SharedDto.BlogPost;
using illegible.Shared.SharedServices.IService;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace illegible.Shared.SharedServices.Service
{
    public class HttpRequestHandlerService : IHttpRequestHandlerService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        
        public HttpRequestHandlerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        /// <summary>
        /// this method get any Dto Type and by uriAddress connect to related api action
        /// so it can sendBack data as same Dto Type
        /// </summary>
        /// <typeparam name="TDto">
        /// any Type of Object You wanna get from api action
        /// it can be list of objects , or just one variable
        /// </typeparam>
        /// <param name="uriAddress">Api action address use routing attributes</param>
        /// <returns></returns>
        public async Task<TDto> GetAsHttpAsync<TDto>(string uriAddress)
        {
            var response = await _httpClient.GetAsync(uriAddress);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var dataAsDto = JsonSerializer.Deserialize<TDto>(content, _options);
            return dataAsDto;
        }

        /// <summary>
        /// ok with this you can post any object to any api action
        /// should use when wanna add a single line in specific table of dataBase
        /// </summary>
        /// <param name="Dto">any single object</param>
        /// <param name="uriAddress">Api action address use routing attributes</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostAsHttpJsonAsync(object Dto, string uriAddress)
        {
            return await _httpClient.PostAsJsonAsync(uriAddress, Dto);
        }

        
        public async Task<TDto> GetByIdAsHttpAsync<TDto>(long id, string uriAddress)
        {
            var aa = await _httpClient.PostAsJsonAsync(uriAddress, id);
            return await _httpClient.GetFromJsonAsync<TDto>(uriAddress); ;
        }

        public async Task<PagingResponse<object>> GetPagedData(PagingParameters pagingParameters, string uriAddress)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString()
            };
            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString("products", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<object>
            {
                Items = JsonSerializer.Deserialize<List<object>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
            };
            return pagingResponse;
        }

    }
}
