using AutoMapper;
using illegible.DataStructure.DataContextDefine;
using illegible.Repository.IRepository.BlogPostTablesIRepository;
using illegible.Repository.Repository.BlogPostRepository;
using illegible.Server.Controllers;
using illegible.Server.Controllers.BlogPostAPI;
using illegible.Server.StartupCleaner;
using illegible.Test.Mock.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace illegible.Test.Fixture
{
    public class ControllerFixture : IDisposable
    {

        private TestDbContextMock testDbContextMock { get; set; }
        private BlogPostRepository _blogPostRepository;
        private UserManager<IdentityUser> _userManager = null;
        private DbSet<Entity.BlogEntity.Post.BlogPost> _blogPost;
        DbContextOptions<DataContext> dbContextOptions;
        private IMapper mapper { get; set; }

        public BlogPost blogPostController { get; private set; }

        public ControllerFixture()
        {
            #region Create mock/memory database

            testDbContextMock = new TestDbContextMock(dbContextOptions);
            _blogPost = testDbContextMock.Set<Entity.BlogEntity.Post.BlogPost>();
            // mock data created by https://barisates.github.io/pretend

            _blogPost.AddRange(new Entity.BlogEntity.Post.BlogPost[]
            {
                // for delete test
                new Entity.BlogEntity.Post.BlogPost() {
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
                },
                // for get test
                new Entity.BlogEntity.Post.BlogPost() {
                    Id = 2,
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
            });

            testDbContextMock.SaveChanges();
            
            #endregion

            #region Mapper settings with original profiles.

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            mapper = mappingConfig.CreateMapper();

            #endregion

            //  Create BlogPostRepository with Memory Database
            _blogPostRepository = new BlogPostRepository(testDbContextMock);

            // Create UserService with Memory Database
            //if (_userManager == null)
            //{
            //    _userManager = new UserManager<IdentityUser>();
            //} 

            // Create Controller
            blogPostController = new BlogPost(_blogPostRepository, mapper, _userManager);

        }

        #region ImplementIDisposableCorrectly
        /** https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1063?view=vs-2019 */
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // NOTE: Leave out the finalizer altogether if this class doesn't
        // own unmanaged resources, but leave the other methods
        // exactly as they are.
        ~ControllerFixture()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                testDbContextMock.Dispose();
                testDbContextMock = null;

                mapper = null;
                _blogPost = null;
                _userManager = null;
                _blogPostRepository = null;
            }
        }
        #endregion
    }
}
