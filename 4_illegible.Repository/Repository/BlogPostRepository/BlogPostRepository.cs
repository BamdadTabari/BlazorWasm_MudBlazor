using illegible.DataStructure.DataContextDefine;
using illegible.Entity.BlogEntity.Post;
using illegible.Kernel.Paging;
using illegible.Kernel.RequestFeatures;
using illegible.Repository.IRepository.BlogPostTablesIRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace illegible.Repository.Repository.BlogPostRepository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private DataContext _dataContext ;
        private DbSet<BlogPost> _blogPost;

        public BlogPostRepository(DataContext dataContext) : base()
        {
            _dataContext = dataContext;
            _blogPost = _dataContext.Set<BlogPost>();
        }

        public async Task<long> AddBlogPostAsync(BlogPost entity)
        {
            await _blogPost.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity.Id;
        }

        public List<BlogPost> GetAllBlogPost()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<BlogPost>> GetAllBlogPostAsync()
        {
            return _blogPost.ToListAsync();
        }

        public Task<BlogPost> GetBlogPostByIdAsync(long id)
        {
            return _blogPost.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<PagedList<BlogPost>> GetPagingPost(PagingParameters pagingParameters)
        {
            var posts = await _blogPost.Search(pagingParameters.SearchTerm).ToListAsync();
            return PagedList<BlogPost>.ToPagedList(posts, pagingParameters.PageNumber, pagingParameters.PageSize);
        }
    }
    public static class BlogPostRepositoryExtensions
    {
        public static IQueryable<BlogPost> Search(this IQueryable<BlogPost> blogPost, string searchTearm)
        {
            if (string.IsNullOrWhiteSpace(searchTearm))
                return blogPost;
            var lowerCaseSearchTerm = searchTearm.Trim().ToLower();
            return blogPost.Where(p => p.Title.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
