using illegible.Shared.SharedDTO.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace illegible.Server.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountsController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        //this method get register view model 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterModelDTO model)
        {
            
            var newUser = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            //i actually try Create user
            var result = 
                await _userManager
                .CreateAsync(newUser, model.Password);

            //check user creating result from user data
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                // send back errors
                return Ok(new RegisterResultDTO
                {
                    Successful = false,
                    Errors = errors
                });

            }

            // send back Successful result
            return Ok(new RegisterResultDTO { Successful = true });
        }
    }
}
