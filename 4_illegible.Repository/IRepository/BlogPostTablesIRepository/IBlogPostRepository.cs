using illegible.Entity.BlogEntity.Post;
using illegible.Kernel.Paging;
using illegible.Kernel.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace illegible.Repository.IRepository.BlogPostTablesIRepository
{
    public interface IBlogPostRepository
    {
        Task<long> AddBlogPostAsync(BlogPost entity);
        Task<BlogPost> GetBlogPostByIdAsync(long id);
        Task<List<BlogPost>> GetAllBlogPostAsync();
        List<BlogPost> GetAllBlogPost();

        //pagination
        Task<PagedList<BlogPost>> GetPagingPost(PagingParameters pagingParameters);
    }
}
