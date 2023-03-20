using DataAccess;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class GradeRepository:IGradeRepository
    {
        GradeDAO gradeDAO = new GradeDAO();
        public UserAnswerTest Grade(int userId, UserAnswerTest userAnswerTest)
        {
            return gradeDAO.Grade(userId, userAnswerTest);
        }
    }
}
