using Microsoft.AspNetCore.Mvc;
using Repositories.Implements;
using Repositories;
using DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PapersController : ControllerBase
    {
        private readonly IPaperRepository paperRepository = new PaperRepository();
        private readonly IUserRepository userRepository = new UserRepository();
        [Authorize]
        [HttpPost("paper")]
        public IActionResult AddPaper(PaperAndPaperQuestionDTO paperAndPaperQuestion)
        {
            try
            {
                var user = HttpContext.User;
                var claims = ((System.Security.Claims.ClaimsIdentity)user.Identity).Claims;
                var items = claims.ToList();
                var jsonstr = items.Last().Value;
                var uid = items[3].Value;

                UserDTO userCurrent = userRepository.GetUserByUid(uid);

                var paper = paperRepository.Add(userCurrent.UserId, paperAndPaperQuestion);
                return Ok(paper);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpGet("papers")]
        public IActionResult GetQuestion()
        {
            try
            {
                var user = HttpContext.User;
                var claims = ((System.Security.Claims.ClaimsIdentity)user.Identity).Claims;
                var items = claims.ToList();
                var jsonstr = items.Last().Value;
                var uid = items[3].Value;

                UserDTO userCurrent = userRepository.GetUserByUid(uid);
                List<PaperAndPaperQuestionDTO> paperAndPaperQuestions = paperRepository.Get(userCurrent.UserId);
                return Ok(paperAndPaperQuestions);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
