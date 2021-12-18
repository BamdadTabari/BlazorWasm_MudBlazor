using illegible.Kernel.RequestFeatures;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace illegible.Client.Shared
{
    public partial class Pagination
    {
        [Parameter]
        public MetaData MetaDataParameter { get; set; }
        [Parameter]
        public int Spread { get; set; }
        [Parameter]
        public EventCallback<int> SelectedPage { get; set; }

        private List<PagingLink> _links;

        protected override void OnParametersSet()
        {
            CreatePaginationLinks();
        }

        private void CreatePaginationLinks()
        {
            _links = new List<PagingLink>();

            _links.Add(new PagingLink(MetaDataParameter.CurrentPage - 1, MetaDataParameter.HasPrevious, "Previous"));

            for (int i = 1; i <= MetaDataParameter.TotalPages; i++)
            {
                if (i >= MetaDataParameter.CurrentPage - Spread && i <= MetaDataParameter.CurrentPage + Spread)
                {
                    _links.Add(new PagingLink(i, true, i.ToString()) { Active = MetaDataParameter.CurrentPage == i });
                }
            }

            _links.Add(new PagingLink(MetaDataParameter.CurrentPage + 1, MetaDataParameter.HasNext, "Next"));
        }

        private async Task OnSelectedPage(PagingLink link)
        {
            if (link.Page == MetaDataParameter.CurrentPage || !link.Enabled)
                return;

            MetaDataParameter.CurrentPage = link.Page;
            await SelectedPage.InvokeAsync(link.Page);
        }
    }
}
