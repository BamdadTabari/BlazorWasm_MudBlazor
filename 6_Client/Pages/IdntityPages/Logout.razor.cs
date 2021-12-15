using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace illegible.Client.Pages.IdntityPages
{
    public partial class Logout
    {
        protected override async Task OnInitializedAsync()
        {
            await _authService.Logout();
            _navigationManager.NavigateTo("/");
        }
    }
}
