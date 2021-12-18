using illegible.DataStructure.DataContextDefine;
using illegible.Entity.BlogEntity.Post;
using illegible.Kernel.Paging;
using illegible.Kernel.RequestFeatures;
using illegible.Repository.IRepository.BlogPostTablesIRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using System;

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
            var posts = await _blogPost.Search(pagingParameters.SearchTerm).Sort(pagingParameters.OrderBy).ToListAsync();
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

        public static IQueryable<BlogPost> Sort(this IQueryable<BlogPost> blogPosts, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return blogPosts.OrderBy(e => e.Title);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(BlogPost).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name
                .Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return blogPosts.OrderBy(e => e.Title);

            return blogPosts.OrderBy(orderQuery);
        }
    }
}
