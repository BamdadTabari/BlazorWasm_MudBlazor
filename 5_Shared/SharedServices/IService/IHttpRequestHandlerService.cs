using illegible.Entity.BlogEntity.Post;
using illegible.Kernel.Paging;
using illegible.Kernel.RequestFeatures;
using System.Net.Http;
using System.Threading.Tasks;

namespace illegible.Shared.SharedServices.IService
{
    // you can see complete docs on HttpRequestHandlerService class
    public interface IHttpRequestHandlerService
    {
        Task<HttpResponseMessage> PostAsHttpJsonAsync(object Dto ,string uriAddress);
        Task<TDto> GetAsHttpAsync<TDto>(string uriAddress);
        Task<TDto> GetByIdAsHttpAsync<TDto>(long id,string uriAddress);

        // files 
        Task<string> UploadStaticImage(MultipartFormDataContent content,string uriAddress);

        //blog post
        Task<PagingResponse<BlogPost>> GetPagedData(PagingParameters pagingParameters, string uriAddress);
    }
}
