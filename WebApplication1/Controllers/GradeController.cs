using Microsoft.AspNetCore.Mvc;
using Repositories.Implements;
using Repositories;
using DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeRepository gradeRepository = new GradeRepository();
        private readonly IUserRepository userRepository = new UserRepository();

        [Authorize]
        [HttpPost("grade")]
        public IActionResult Grade(UserAnswerTest userAnswerTest)
        {
            try
            {
                var user = HttpContext.User;
                var claims = ((System.Security.Claims.ClaimsIdentity)user.Identity).Claims;
                var items = claims.ToList();
                var jsonstr = items.Last().Value;
                var uid = items[3].Value;

                UserDTO userCurrent = userRepository.GetUserByUid(uid);

                var userAnswerTest2 = gradeRepository.Grade(userCurrent.UserId, userAnswerTest);
                return Ok(userAnswerTest2);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
