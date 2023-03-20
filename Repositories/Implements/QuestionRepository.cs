using DataAccess.DTO;
using DataAccess.Util;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories.Implements
{
    public class QuestionRepository :IQuestionRepository
    {

        QuestionDAO questionDAO = new QuestionDAO();
        public QuestionAndAnswerDTO Add(int userId, QuestionAndAnswerDTO QuestionAndAnswerDTO)
        {
            return questionDAO.AddQuestion(userId, QuestionAndAnswerDTO);
        }

        public List<QuestionAndAnswerDTO> Get(int uid)
        {
            return questionDAO.GetQuestionsByUserId(uid);
        }

        public TestInfor GetByAccessKey(string accessKey)
        {
            return questionDAO.GetQuestionsByAccessKey(accessKey);
        }
    }
}
