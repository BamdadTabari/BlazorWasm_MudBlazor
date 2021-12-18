using illegible.Kernel.Paging;
using illegible.Kernel.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace illegible.Client.Pages.BlogPost
{
    public partial class PagedBlogPosts
    {
        //protected override async Task OnInitializedAsync()
        //{
        //    var bb = await Http.GetAsync("BlogPost/GetPagedBlogPosts");
        //    var aa = bb;
        //}
        public List<Entity.BlogEntity.Post.BlogPost> BlogPosts { get; set; } = new List<Entity.BlogEntity.Post.BlogPost>();
        public MetaData MetaData { get; set; } = new MetaData();
        private PagingParameters _pagingParameters = new PagingParameters();
      
        protected async override Task OnInitializedAsync()
        {
            await GetPosts();
        }
        private async Task SelectedPage(int page)
        {
            _pagingParameters.PageNumber = page;
            await GetPosts();
        }
        private async Task GetPosts()
        {
            var pagingResponse = await _httpRequestHandler.GetPagedData(_pagingParameters, "BlogPost/GetPagedBlogPosts");
            BlogPosts = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }
    }
}
