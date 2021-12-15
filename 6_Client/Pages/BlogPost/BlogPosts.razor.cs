using illegible.Shared.SharedDto.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace illegible.Client.Pages.BlogPost
{
    public partial class BlogPosts
    {
        private BlogPostDto[] BlogPostDtoList;
        protected override async Task OnInitializedAsync()
        {
            BlogPostDtoList = await Http.GetFromJsonAsync<BlogPostDto[]>("BlogPost/GetAllBlogPost");
        }
        void SeePost(long? id)
        {
            _navigationManager.NavigateTo($"/Post/{id}");
        }
    }
}
