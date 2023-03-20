using DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Implements;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository = new UserRepository();


        [HttpPost("register")]
        public IActionResult Register(UserDTO userDTO)
        {
            try
            {
                userRepository.Add(userDTO);

                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("user-current")]
        [Authorize]
        public IActionResult GetUserCurrent(string uid)
        {
            try
            {
                UserDTO user = userRepository.GetUserByUid(uid);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
