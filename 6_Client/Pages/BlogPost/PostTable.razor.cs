using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace illegible.Client.Pages.BlogPost
{
    public partial class PostTable
    {
        [Parameter]
        public List<Entity.BlogEntity.Post.BlogPost> BlogPosts { get; set; }
    }
}
