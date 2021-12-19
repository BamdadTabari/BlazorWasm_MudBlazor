using illegible.Shared.SharedDto.BlogPost;
using System.Threading.Tasks;

namespace illegible.Client.Pages.BlogPost
{
    public partial class CreatePost
    {
        public BlogPostDto BlogPostData = new();


        private async Task Create()
        {
            await _httpRequestHandler.PostAsHttpJsonAsync(BlogPostData, "BlogPost/AddBlogPost");
        }
    }
}
