using illegible.Entity.BlogEntity.Post;
using illegible.Repository.IRepository.BlogPostTablesIRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace illegible.Test
{
    public class BlogPostFakeRepository : IBlogPostRepository
    {
        private readonly List<BlogPost> _blogPosts;

        public BlogPostFakeRepository()
        {
            _blogPosts = new List<BlogPost>()
            {
              new BlogPost() {
                    Id = 1,
                    Author = "",
                    AttachedLinkTypeEnum = Kernel.Enums.AttachedLinkType.GitHub,
                    ModifiedDate = DateTime.Today,
                    PostAttachedLinkUrl = "",
                    PostAttachedLinkUrlSubject = "",
                    PostContext = "",
                    PostImageUrl = "",
                    PostVideoUrl = "",
                    Summary = "",
                    Title = "",
                    WriteTime = DateTime.Today
                }
            };
        }

        public Task<long> AddBlogPostAsync(BlogPost entity)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllBlogPost()
        {
            List<BlogPost> blogPosts = new List<BlogPost>()
            {
              new BlogPost() {
                    Id = 1,
                    Author = "",
                    AttachedLinkTypeEnum = Kernel.Enums.AttachedLinkType.GitHub,
                    ModifiedDate = DateTime.Today,
                    PostAttachedLinkUrl = "",
                    PostAttachedLinkUrlSubject = "",
                    PostContext = "",
                    PostImageUrl = "",
                    PostVideoUrl = "",
                    Summary = "",
                    Title = "",
                    WriteTime = DateTime.Today
                }
            };
            return blogPosts;
        }

        public async Task<List<BlogPost>> GetAllBlogPostAsync()
        {
            return _blogPosts;
        }

        public Task<BlogPost> GetBlogPostByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
