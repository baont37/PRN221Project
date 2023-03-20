using BusinessObjects;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SectionDAO
    {
        public SectionDTO AddSection(SectionDTO sectionDTO)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var section = new Section();
                    section.Name = sectionDTO.Name;
                    section.AccessKey = sectionDTO.AccessKey;
                    section.TimeLimit = sectionDTO.TimeLimit;
                    section.ActivatedAt = sectionDTO.ActivatedAt;
                    section.PaperId = sectionDTO.PaperId;
                    context.Sections.Add(section);
                    context.SaveChanges();
                    var temp = section;
                    sectionDTO.SectionId = temp.SectionId;
                }
                return sectionDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
