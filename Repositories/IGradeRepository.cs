using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IGradeRepository
    {
        UserAnswerTest Grade(int userId, UserAnswerTest userAnswerTest);

    }
}
