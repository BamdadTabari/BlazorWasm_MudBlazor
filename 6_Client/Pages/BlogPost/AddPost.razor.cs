using illegible.Client.Extensions.TelerikBlazorExtension;
using illegible.Shared.SharedDto.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace illegible.Client.Pages.BlogPost
{
    public partial class AddPost
    {
        public BlogPostDto BlogPost = new BlogPostDto();
        protected async Task AddBlogPost()
        {
            var responseMessage = await _httpRequestHandler.PostAsHttpJsonAsync(BlogPost,"BlogPost/AddBlogPost");
            if (responseMessage.IsSuccessStatusCode)
            {
                TelerikClasses.NotificationShow("Post Added Successfully", "success", "plus-sm");
            }
            else
            {
                TelerikClasses.NotificationShow("Failed To Add Post", "error", "x");
            }
        }
    }
}
