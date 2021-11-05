using illegible.Entity.BlogEntity.Post;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace illegible.Repository.IRepository.BlogPostTablesIRepository
{
    public interface IBlogPostRepository
    {
        Task<long> AddBlogPostAsync(BlogPost entity);
        Task<BlogPost> GetBlogPostByIdAsync(long id);
        Task<List<BlogPost>> GetAllBlogPostAsync();
    }
}
