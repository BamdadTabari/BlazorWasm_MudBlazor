using Microsoft.AspNetCore.Components;

namespace illegible.Client.Shared
{
    public partial class Search
    {
        public string SearchTerm { get; set; }
        [Parameter]
        public EventCallback<string> OnSearchChanged { get; set; }
    }
}
