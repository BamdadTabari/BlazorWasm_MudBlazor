//using illegible.Entity.BaseEntities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace illegible.Entity.BlogEntity.Post
//{
//    public class BlogPostComment : BaseEntity
//    {
//        public long CommentUserId { get; set; }
//        public string CommentContext { get; set; }

//        //relations 
//        public BlogPost BlogPost { get; set; }
//    }

//    public class BlogPostCommentCnfiguration : IEntityTypeConfiguration<BlogPostComment>
//    {
//        public void Configure(EntityTypeBuilder<BlogPostComment> builder)
//        {
//            #region Required
//            builder.Property(b => b.CommentUserId)
//                .IsRequired();

//            builder.Property(b => b.CommentContext)
//                .IsRequired();
//            #endregion
//        }
//    }
//}
