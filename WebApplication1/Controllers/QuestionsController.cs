using BusinessObjects;
using DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repositories;
using Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.NewFolder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository questionRepository = new QuestionRepository();
        private readonly IUserRepository userRepository = new UserRepository();

        [Authorize]
        [HttpPost("question")]
        public IActionResult AddQuestion(QuestionAndAnswerDTO questionAndAnswer)
        {
            try
            {
                var user = HttpContext.User;
                var claims = ((System.Security.Claims.ClaimsIdentity)user.Identity).Claims;
                var items = claims.ToList();
                var jsonstr = items.Last().Value;
                var uid = items[3].Value;

                UserDTO userCurrent = userRepository.GetUserByUid(uid);
                var questionAndAnswer1 = new QuestionAndAnswerDTO();
                if (userCurrent.Role == 1)
                {
                    questionAndAnswer1 = questionRepository.Add(userCurrent.UserId, questionAndAnswer);                 
                }
                return Ok(questionAndAnswer1);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Authorize]
        [HttpGet("questions")]
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
                List<QuestionAndAnswerDTO> questionAndAnswers = questionRepository.Get(userCurrent.UserId);
                return Ok(questionAndAnswers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpGet("accessKey")]
        public IActionResult GetQuestionBySectionId(string accessKey)
        {
            try
            {
                /*var user = HttpContext.User;
                var claims = ((System.Security.Claims.ClaimsIdentity)user.Identity).Claims;
                var items = claims.ToList();
                var jsonstr = items.Last().Value;
                var uid = items[3].Value;

                UserDTO userCurrent = userRepository.GetUserByUid(uid);*/
                TestInforDTO testInfor = questionRepository.GetByAccessKey(accessKey);
                return Ok(testInfor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpGet("search")]
        public IActionResult GetQuestionBySearch(string searchKey)
        {
            try
            {
                var user = HttpContext.User;
                var claims = ((System.Security.Claims.ClaimsIdentity)user.Identity).Claims;
                var items = claims.ToList();
                var jsonstr = items.Last().Value;
                var uid = items[3].Value;
                UserDTO userCurrent = userRepository.GetUserByUid(uid);
                List<QuestionAndAnswerDTO> questionAndAnswers = questionRepository.GetBySearch(userCurrent.UserId, searchKey);
                return Ok(questionAndAnswers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpGet("paging")]
        public IActionResult GetQuestionByPaging(int pageNumber, int pageSize)
        {
            try
            {
                var user = HttpContext.User;
                var claims = ((System.Security.Claims.ClaimsIdentity)user.Identity).Claims;
                var items = claims.ToList();
                var jsonstr = items.Last().Value;
                var uid = items[3].Value;
                UserDTO userCurrent = userRepository.GetUserByUid(uid);
                List<QuestionAndAnswerDTO> questionAndAnswers = questionRepository.GetByPaging(userCurrent.UserId, pageNumber, pageSize);
                return Ok(questionAndAnswers);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
