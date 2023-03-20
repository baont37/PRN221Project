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

        List<PaperAndPaperQuestionDTO> GetPaperAndPaperQuestionsByPaging(int uid, int page, int pageSize);

        List<PaperAndPaperQuestionDTO> GetPaperAndPaperQuestionsBySearch(int uid,string searchKey);

    }
}
