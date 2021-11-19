using illegible.Shared.SharedDto.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace illegible.Shared.SharedServices.IService
{
    public interface IAuthService
    {
        Task<RegisterResultDto> Register(RegisterModelDto registerModel);
        Task<LoginResultDto> Login(LoginModelDto loginModel);
        Task Logout();
    }
}
