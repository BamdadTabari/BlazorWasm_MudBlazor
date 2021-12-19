using illegible.Kernel.Enums;
using illegible.Shared.BaseDto;
using System;

using System.ComponentModel.DataAnnotations;


namespace illegible.Shared.SharedDto.BlogPost
{
    public class BlogPostDto : BlogBaseDto
    {
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        [Required]
        public string Summary { get; set; }
        public DateTime WriteTime { get; set; } 
        
        [Required]
        public string PostContext { get; set; }

        [Url]
        public string PostImageUrl { get; set; }

        [Url]
        public string PostVideoUrl { get; set; }
        public AttachedLinkType AttachedLinkTypeEnum { get; set; }

        [Url]
        public string PostAttachedLinkUrl { get; set; }
        public string PostAttachedLinkUrlSubject { get; set; }
        public string ImageUrl { get; set; }
    }
}
