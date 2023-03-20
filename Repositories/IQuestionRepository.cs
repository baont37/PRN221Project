using BusinessObjects;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IQuestionRepository
    {
        QuestionAndAnswerDTO Add(int uid, QuestionAndAnswerDTO questionAndAnswer);

        List<QuestionAndAnswerDTO> Get(int uid);

        TestInfor GetByAccessKey(string sectionId);
    }
}
