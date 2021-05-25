using GlobalHelpers.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services.Interfaces;
using SharedConfig.Config;
using SharedConfig.Messages;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly AppConfig _config;
        private readonly IUserService _userService;
        public AuthenticateController(AppConfig config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] VmLoginRequest LoginRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User user = await _userService.ValidateUserToLogin(LoginRequest.UserName, LoginRequest.Password);
                    List<Claim> authClaims = new()
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.Role.ToString()),
                    };

                    SymmetricSecurityKey authSigningKey = new(Encoding.UTF8.GetBytes(_config.JWTConfig.Secret));

                    JwtSecurityToken token = new(
                        issuer: _config.JWTConfig.ValidIssuer,
                        audience: _config.JWTConfig.ValidAudience,
                        expires: DateTime.Now.AddHours(_config.JWTConfig.Expires),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    string JWTToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(DataMessage.Data(new VmLoginResponse()
                    {
                        Token = JWTToken
                    }));
                }
                catch (AppException ex)
                {
                    return BadRequest(ex.ReturnBadRequest());
                }
                catch (Exception ex)
                {
                    return BadRequest(AppException.ReturnBadRequest(ex.Message));
                }
            }
            else
            {
                return BadRequest(AppException.ReturnBadRequest(ModelState));
            }
        }
    }
}
