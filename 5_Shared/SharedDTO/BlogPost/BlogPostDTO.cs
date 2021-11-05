using illegible.Kernel.Enums;
using illegible.Shared.BaseDTO;
using System;

using System.ComponentModel.DataAnnotations;


namespace illegible.Shared.SharedDTO.BlogPost
{
    public class BlogPostDTO : BlogBaseDTO
    {
        [Required]
        
        public string Title { get; set; }
        public string Author { get; set; }
        [Required]
        
        public string Summary { get; set; }
        public DateTime WriteTime { get; set; }
        [Required]
        
        public string PostContext { get; set; }
        
        public string PostImageUrl { get; set; }
        
        public string PostVideoUrl { get; set; }
        
        public string PostAttachedFileUrl { get; set; }

        //public AttachedLinkType AttachedLinkTypeEnum { get; set; }
        
        public string PostAttachedLinkUrl { get; set; }
    }
}
