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
        public List<Entity.BlogEntity.Post.BlogPost> blogPosts { get; set; } = new List<Entity.BlogEntity.Post.BlogPost>();
        public MetaData metaData { get; set; } = new illegible.Kernel.RequestFeatures.MetaData();
        private PagingParameters _pagingParameters = new PagingParameters();
      
        protected async override Task OnInitializedAsync()
        {
            var pagingResponse = await _httpRequestHandler.GetPagedData(_pagingParameters , "BlogPost/GetPagedBlogPosts");
            blogPosts = pagingResponse.Items;
            metaData = pagingResponse.MetaData;
        }
    }
}
