//using illegible.Entity.BlogEntity.Post;
//using illegible.Repository.IRepository.BlogPostTablesIRepository;
//using illegible.Repository.Repository.BlogPostRepository;
//using System;
//using Xunit;
//using System.Collections.Generic;

//using Moq;
//using illegible.Shared.SharedDto.BlogPost;
//using System.Threading.Tasks;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;

//namespace illegible.Test
//{
//    [ExcludeFromCodeCoverage]
//    public class BlogPostRepositoryTest
//    {
//        Mock<BlogPostFakeRepository> blogPost;

//        public BlogPostRepositoryTest()
//        {
//            this.blogPost = new Mock<BlogPostFakeRepository>();
//        }
//        [Fact]
//        public void Get_WhenCalled_ReturnsOkResult()
//        {
//            List<BlogPost> blogPosts = new List<BlogPost>()
//            {
//              new BlogPost() {
//                    Id = 1,
//                    Author = "",
//                    AttachedLinkTypeEnum = Kernel.Enums.AttachedLinkType.GitHub,
//                    ModifiedDate = DateTime.Today,
//                    PostAttachedLinkUrl = "",
//                    PostAttachedLinkUrlSubject = "",
//                    PostContext = "",
//                    PostImageUrl = "",
//                    PostVideoUrl = "",
//                    Summary = "",
//                    Title = "",
//                    WriteTime = DateTime.Today
//                }
//            };
//            //blogPost.Setup(x => x.GetAllBlogPost()).Returns(blogPosts);
//            Assert.Single((blogPost.Object.GetAllBlogPost()));
//        }
//    }
//}
