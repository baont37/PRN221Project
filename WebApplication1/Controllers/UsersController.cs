using DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using Repositories.Implements;
using Repositories;
using System;
using System.Collections.Generic;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository = new UserRepository();

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                List<UserDTO> userDTO = userRepository.GetAll();
                return Ok(userDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult register(UserDTO userDTO)
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

    }
}
