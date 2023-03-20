using BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class QuestionAndAnswerDTO
    {
        public int QuestionId { get; set; }
        //[Column("text")]

        //[Column("isMultiChoice")]
        public bool IsMultiChoice { get; set; }

        [Required]
        //[Column("lever")]
        public int Lever { get; set; }

        //[Column("type")]
        public string Type { get; set; }

        public string Text { get; set; }

        public List<AnswerDTO> Answers { get; set; }
    }
}
