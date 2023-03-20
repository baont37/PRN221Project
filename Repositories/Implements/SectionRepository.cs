using DataAccess.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class SectionRepository :ISectionRepository
    { 
    
        SectionDAO sectionDAO = new SectionDAO();
        public SectionDTO Add(SectionDTO sectionDTO)
        {
            return sectionDAO.AddSection(sectionDTO);
        }

        public List<SectionDTO> GetSectionsByUserId(int userId)
        {
            return sectionDAO.GetSectionsByUserId(userId);
        }
    }
}
