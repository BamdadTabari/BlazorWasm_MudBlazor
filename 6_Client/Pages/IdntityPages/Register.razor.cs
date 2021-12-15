using illegible.Client.Extensions.TelerikBlazorExtension;
using illegible.Shared.SharedDto.Identity;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace illegible.Client.Pages.IdntityPages
{
    public partial class Register
    {
        #region Props

        private int IndexValue { get; set; }
        private Terms TermsModel { get; set; } = new Terms();
        private RegisterModelDto _registerModel = new RegisterModelDto();
        public EditContext RegistrationEditContext { get; set; }

        #endregion

        #region Actions
        protected override void OnInitialized()
        {
            InitRegistration(); base.OnInitialized();
        }
        private void OnClear()
        {
            _registerModel = new RegisterModelDto(); InitRegistration();
        }
        private void InitRegistration() => RegistrationEditContext = new EditContext(_registerModel);
        private async Task HandleRegistration()
        {
            var result = await _authService.Register(_registerModel);
            if (result.Successful)
            {
                TelerikClasses.NotificationShow("The Registration Is Completed Successfully", "success", "user");

                _navigationManager.NavigateTo("/login");
            }
            else
            {
                TelerikClasses.NotificationShow("The Registration Failed", "error", "lock");
                IndexValue = 0;
            }
        }
        #endregion
    }
}
