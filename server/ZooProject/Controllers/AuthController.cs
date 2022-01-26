using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooProject.BLL.Interfaces;
using ZooProject.DAL.Models;

namespace ZooProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterModel registerModel)
        {
            var result = await _authManager.Register(registerModel);

            if (result == true)
            {
                return Ok(new { message = "Success!" });
            }
            else
            {
                return BadRequest("Nope. Something went wrong!");
            }
        }

        [HttpPost("LogIn")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn([FromBody] LoginModel loginModel)
        {
            var token = await _authManager.Login(loginModel);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    }
}
