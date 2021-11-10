using illegible.Entity.BaseEntities;
using illegible.Kernel.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace illegible.Entity.BlogEntity.Post
{
    public class BlogPost : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public DateTime WriteTime { get; set; }
        public string PostContext { get; set; }
        public string PostImageUrl { get; set; }
        public string PostVideoUrl { get; set; }
        public AttachedLinkType AttachedLinkTypeEnum { get; set; }
        public string PostAttachedLinkUrl { get; set; }
        public string PostAttachedLinkUrlSubject { get; set; }

        //relation
        //public List<BlogPostComment> BlogPostCommentList { get; set; }
    }

    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            #region Required
            builder.Property(b => b.Title)
                .IsRequired();

            builder.Property(b => b.Author)
               .IsRequired();

            builder.Property(b => b.Summary)
               .IsRequired();

            builder.Property(b => b.WriteTime)
              .IsRequired();

            builder.Property(b => b.PostContext)
                .IsRequired();

            #endregion
        }
    }
}

