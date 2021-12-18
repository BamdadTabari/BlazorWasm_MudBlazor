//using illegible.Entity.BlogEntity.Post;
//using illegible.DataStructure.DataContextDefine;
//using Microsoft.EntityFrameworkCore;
//using System;
//using illegible.Test.Mock.Entities;

//namespace illegible.Test.Fixture
//{
//    public class ContextFixture : IDisposable
//    {
//        public TestDbContextMock testDbContextMock;
//        DbContextOptions<DataContext> dbContextOptions;
//        private DbSet<BlogPost> _blogPost;
//        public ContextFixture()
//        {
//            testDbContextMock = new TestDbContextMock(dbContextOptions);
//            _blogPost = testDbContextMock.Set<BlogPost>();
//            // mock data created by https://barisates.github.io/pretend
           
//            _blogPost.AddRange(new BlogPost[]
//            {
//                // for delete test
//                new BlogPost() {
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
//                },
//                // for get test
//                new BlogPost() {
//                    Id = 2,
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
//            });
//            testDbContextMock.SaveChanges();
//        }
//        #region ImplementIDisposableCorrectly
//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        // NOTE: Leave out the finalizer altogether if this class doesn't
//        // own unmanaged resources, but leave the other methods
//        // exactly as they are.
//        ~ContextFixture()
//        {
//            // Finalizer calls Dispose(false)
//            Dispose(false);
//        }

//        // The bulk of the clean-up code is implemented in Dispose(bool)
//        protected virtual void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                // free managed resources
//                if (testDbContextMock != null)
//                {
//                    testDbContextMock.Dispose();
//                    testDbContextMock = null;
//                }
//            }
//        }
//        #endregion
//    }
//}
