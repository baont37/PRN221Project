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

        public List<QuestionAndAnswerDTO> Get(int uerId)
        {
            return questionDAO.GetQuestionsByUserId(uerId);
        }

        public TestInforDTO GetByAccessKey(string accessKey)
        {
            return questionDAO.GetQuestionsByAccessKey(accessKey);
        }

        public List<QuestionAndAnswerDTO> GetBySearch(int userId, string searchKey)
        {
            return questionDAO.GetQuestionsBySearch(userId,  searchKey);
        }

        public List<QuestionAndAnswerDTO> GetByPaging(int userId, int pageNumber, int pageSize)
        {
            return questionDAO.GetQuestionsByPaging(userId, pageNumber, pageSize);
        }

    }
}
