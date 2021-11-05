using illegible.Shared.SharedDTO.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace illegible.Shared.SharedServices.IService
{
    public interface IAuthService
    {
        Task<RegisterResultDTO> Register(RegisterModelDTO registerModel);
        Task<LoginResultDTO> Login(LoginModelDTO loginModel);
        Task Logout();
    }
}
