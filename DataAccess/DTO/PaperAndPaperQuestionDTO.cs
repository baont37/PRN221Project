using BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class PaperAndPaperQuestionDTO
    {
        public int PaperId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<PaperQuestionDTO> PaperQuestions { get; set; }
    }
}
