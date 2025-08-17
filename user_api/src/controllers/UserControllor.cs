using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace ProductApplication.Models
{
   [ApiController]
    [Route("api/Users")]
    public class UserController : ControllerBase
    {
        private readonly UsersServices _userServices;

        public UserController(UsersServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");
            }
            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetAllUsers), new { id = user.userId }, user);
        }
    }

}