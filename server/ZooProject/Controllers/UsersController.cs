using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooProject.BLL.Interfaces;
using ZooProject.Constants;

namespace ZooProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public UsersController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpGet("GetAllUsers")]
        [Authorize(Roles = UserRoleTypes.Admin)]
        public async Task<IActionResult> GetAllAnimals()
        {
            var strings = await _authManager.GetAll();

            return Ok(strings);
        }
    }
}
