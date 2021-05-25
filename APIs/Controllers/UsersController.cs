using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using GlobalHelpers.Helpers;
using SharedConfig.Messages;
using Models.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UsersController(IMapper Mapper,IUserService UserService)
        {
            this._mapper = Mapper;
            this._userService = UserService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUser([FromBody] VmUserCreate vmUserCreate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User createdUser = await _userService.CreateUser(vmUserCreate);
                    VmUser vmUser = _mapper.Map<VmUser>(createdUser);
                    return Ok(DataMessage.Data(vmUser));
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
