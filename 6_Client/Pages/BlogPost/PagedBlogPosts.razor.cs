using illegible.Kernel.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace illegible.Client.Pages.BlogPost
{
    public partial class PagedBlogPosts
    {
        private PagedList<BlogPost> BlogPostDtoList;
        protected override async Task OnInitializedAsync()
        {
            BlogPostDtoList = await Http.GetFromJsonAsync<PagedList<BlogPost>>("BlogPost/GetPagedBlogPosts");
            var aa = BlogPostDtoList;
        }
        void SeePost(long? id)
        {
            _navigationManager.NavigateTo($"/Post/{id}");
        }
    }
}
