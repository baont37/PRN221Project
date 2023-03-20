using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IPaperRepository
    {
        PaperAndPaperQuestionDTO Add(int uid, PaperAndPaperQuestionDTO paperAndPaperQuestion);

        List<PaperAndPaperQuestionDTO> Get(int uid);

    }
}
