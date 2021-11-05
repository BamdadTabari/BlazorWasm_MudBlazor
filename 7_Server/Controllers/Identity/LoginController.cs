using illegible.Kernel.Constants;
using illegible.Shared.SharedDTO.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace illegible.Server.Controllers.Identity
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModelDTO login)
        {
            // so simple
            // i try to sign in User with password
            var result = await _signInManager
                .PasswordSignInAsync(login.Email,
                login.Password, false, false);

            // in case of error 
            if (!result.Succeeded) return BadRequest(new LoginResultDTO
            {
                Successful = false,
                Error = "Username or password are invalid."
            });


            // claim defult is on email
            // cause user name is the same as email
            // you can change it or set it dynamic
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login.Email)
            };

            // const data from kernel (read this class comments)
            var jwtSetting = new JwtSetting();
            // this is what i love in this code
            // we generate SigningCredential Key
            // with encoding our jwt long private key in utf8
            var key = new SymmetricSecurityKey(Encoding
                .UTF8
                .GetBytes(jwtSetting.SecuritySignInKey));

            // create SigningCredentials by
            // hashing  generated key i defined above in Hmac256
            // (i call it pretty little kido Cryptography algorithm)
            var creds = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256);

            // set token expire time for one day
            var expiry = DateTime.Now.AddDays
                (Convert.ToInt32(1));


            var token = new JwtSecurityToken(
                //jwt issuer
                jwtSetting.ValidIssuer,
                //jwt audience
                jwtSetting.ValidAudience,
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            //serialize jwt token
            var jweToken = new JwtSecurityTokenHandler()
                .WriteToken(token);

            // and there we go returning LoginResultDTO with token
            return Ok(new LoginResultDTO
            {
                Successful = true,
                Token = jweToken
            });
        }
    }
}
