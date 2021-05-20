using APIs.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthenticateController(IConfiguration Configuration)
        {
            this._configuration = Configuration;
        }

        [Route("login")]
        [HttpPost]
        public VmLoginResponse Login(VmLoginRequest LoginRequest)
        {
            if(LoginRequest.UserName.Equals("admin") && LoginRequest.Password.Equals("admin"))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Yasser"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                authClaims.Add(new Claim(ClaimTypes.Role, "Admin"));
                authClaims.Add(new Claim(ClaimTypes.Role, "Manager"));

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return new VmLoginResponse()
                {
                    Status = "Success",
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }

            return new VmLoginResponse() { Status  = "InvalidLogin" };
            
        }
    }
}
