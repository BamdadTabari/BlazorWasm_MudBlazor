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
            var bb = await Http.GetAsync("BlogPost/GetPagedBlogPosts");
            var aa = bb;
        }
        void SeePost(long? id)
        {
            _navigationManager.NavigateTo($"/Post/{id}");
        }
    }
}
