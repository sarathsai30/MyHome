using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHome.Data;
using MyHome.DTOs;
using MyHome.Models;

namespace MyHome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepo;
        public AuthController(AuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> Register(UserDTO user) {
            ServiceResponse<int> response = await _authRepo.Register(new User { UserName = user.UserName }, user.Password);
            if (!response.Success) {
                return BadRequest(response);
            }
            return Ok();
         
        }

    }
}
