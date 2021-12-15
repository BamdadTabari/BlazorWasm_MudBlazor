using illegible.DataStructure.DataContextDefine;
using illegible.Entity.BlogEntity.Post;
using illegible.Repository.IRepository.BlogPostTablesIRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

    }
}
