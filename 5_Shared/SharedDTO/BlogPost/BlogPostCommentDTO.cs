using illegible.Shared.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace illegible.Shared.SharedDto.BlogPost
{
    public class BlogPostCommentDto : BlogBaseDto
    {
        public long CommentUserId { get; set; }
        public string CommentContext { get; set; }
    }
}
