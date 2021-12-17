using illegible.Shared.SharedDto.BlogPost;
using System;
using Xunit;

namespace dotnet_core_xunit_test.Theory
{
    public class BlogPostTheoryData: TheoryData<BlogPostDto>
    {
        public BlogPostTheoryData()
        {
            /**
             * Each item you add to the TheoryData collection will try to pass your unit test's one by one.
             */

            Add(new BlogPostDto()
            {
                Id = 3,
                Author = "",
                AttachedLinkTypeEnum = illegible.Kernel.Enums.AttachedLinkType.GitHub,
                ModifiedDate = DateTime.Today,
                PostAttachedLinkUrl = "https://github.com/MohammadJavadTabari",
                PostAttachedLinkUrlSubject = "",
                PostContext = "",
                PostImageUrl = "https://github.com/MohammadJavadTabari",
                PostVideoUrl = "https://github.com/MohammadJavadTabari",
                Summary = "",
                Title = "",
                WriteTime = DateTime.Today
            });
        }
    }
}
