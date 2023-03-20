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

        public List<SectionDTO> GetSectionsByUserId(int userId)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    List < SectionDTO > sectionDTOs= new  List <SectionDTO> ();
                    var papers = context.Papers.Where(o => o.UserId == userId).ToList();
                    List<Section> sections = new List <Section> ();
                    foreach (var item in papers)
                    {
                        List<Section> sectionItems = context.Sections.Where(o => o.PaperId == item.PaperId).ToList();
                        foreach (var item2 in sectionItems)
                        {
                            sections.Add(item2);
                        }                     
                    }
                    foreach (var item in sections)
                    {
                        SectionDTO sectionDTO = new SectionDTO();
                        sectionDTO.SectionId = item.SectionId;
                        sectionDTO.TimeLimit = item.TimeLimit;
                        sectionDTO.ActivatedAt = item.ActivatedAt;
                        sectionDTO.AccessKey = item.AccessKey;
                        sectionDTO.Name = item.Name;
                        sectionDTO.PaperId = item.PaperId;
                        sectionDTOs.Add(sectionDTO);
                    }
                    return sectionDTOs;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
