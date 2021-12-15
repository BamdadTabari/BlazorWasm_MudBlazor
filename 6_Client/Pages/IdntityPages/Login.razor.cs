using illegible.Shared.SharedDto.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace illegible.Client.Pages.IdntityPages
{
    public partial class Login
    {
        public LoginModelDto _loginModel = new LoginModelDto();
        private bool ShowErrors;
        private string Error = "";

        private async Task HandleLogin()
        {
            ShowErrors = false;

            var result = await _authService.Login(_loginModel);

            if (result.Successful)
            {
                _navigationManager.NavigateTo("/");
            }
            else
            {
                Error = result.Error;
                ShowErrors = true;
            }
        }
    }
}
