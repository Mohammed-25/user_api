using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace ProductApplication.Models
{
    [ApiController]
    [Route("api/[[Users]]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;
        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userServices.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userServices.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");
            }
            await _userServices.AddUser(user);
            return CreatedAtAction(nameof(GetAllUsers), new { id = user.userId }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] Users updatedUser)
        {
            var existingUser = await _userServices.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.userName = updatedUser.userName;
            existingUser.email = updatedUser.email;
            existingUser.adreess = updatedUser.adreess;
            await _userServices.UodateUser(id, existingUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var existingUser = await _userServices.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            await _userServices.DeleteUser(id);
            return NoContent();
        }
    }

}