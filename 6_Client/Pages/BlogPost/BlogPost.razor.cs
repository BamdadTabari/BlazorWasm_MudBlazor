using illegible.Shared.SharedDto.BlogPost;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace illegible.Client.Pages.BlogPost
{
    public partial class BlogPost
    {
        [Parameter]
        public long PostId { get; set; }
        protected BlogPostDto BlogPostDto = new BlogPostDto();
        protected override async Task OnInitializedAsync()
        {
            BlogPostDto = await _httpRequestHandler.GetAsHttpAsync<BlogPostDto>($"BlogPost/GetBlogPost/{PostId}");
        }
    }
}
