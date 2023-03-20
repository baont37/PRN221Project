using DataAccess.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class PaperRepository:IPaperRepository
    {
        PaperDAO paperDAO = new PaperDAO();
        public PaperAndPaperQuestionDTO Add(int userId, PaperAndPaperQuestionDTO paperAndPaperQuestion)
        {
            return paperDAO.AddPaper(userId, paperAndPaperQuestion);
        }
        public List<PaperAndPaperQuestionDTO> Get(int uid)
        {
            return paperDAO.GetPaperAndPaperQuestionsByUserId(uid);
        }

        public List<PaperAndPaperQuestionDTO> GetPaperAndPaperQuestionsByPaging(int uid, int page, int pageSize)
        {
            return paperDAO.GetPaperAndPaperQuestionsByPaging(uid,page,pageSize);
        }

        public List<PaperAndPaperQuestionDTO> GetPaperAndPaperQuestionsBySearch(int uid,string searchKey)
        {
            return paperDAO.GetPaperAndPaperQuestionsBySearch(uid,searchKey);
        }

    }
}
