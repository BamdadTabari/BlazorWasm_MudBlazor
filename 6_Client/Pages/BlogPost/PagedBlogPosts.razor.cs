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
        public List<Entity.BlogEntity.Post.BlogPost> BlogPosts { get; set; } = new List<Entity.BlogEntity.Post.BlogPost>();
        public MetaData MetaData { get; set; } = new MetaData();
        private PagingParameters _pagingParameters = new PagingParameters();
      
        private async Task GetPosts()
        {
            var pagingResponse = await _httpRequestHandler.GetPagedData(_pagingParameters, "BlogPost/GetPagedBlogPosts");
            BlogPosts = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }
        protected async override Task OnInitializedAsync()
        {
            await GetPosts();
        }
        private async Task SelectedPage(int page)
        {
            _pagingParameters.PageNumber = page;
            await GetPosts();
        }
        private async Task SearchChanged(string searchTerm)
        {
            Console.WriteLine(searchTerm);
            _pagingParameters.PageNumber = 1;
            _pagingParameters.SearchTerm = searchTerm;
            await GetPosts();
        }
        private async Task SortChanged(string orderBy)
        {
            Console.WriteLine(orderBy);
            _pagingParameters.OrderBy = orderBy;
            await GetPosts();
        }
    }
}
