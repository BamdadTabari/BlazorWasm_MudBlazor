using illegible.Shared.BaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace illegible.Shared.SharedDTO.BlogPost
{
    public class BlogPostCommentDTO : BlogBaseDTO
    {
        public long CommentUserId { get; set; }
        public string CommentContext { get; set; }
    }
}
