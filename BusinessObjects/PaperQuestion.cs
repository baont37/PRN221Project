using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BusinessObjects
{
    public class PaperQuestion
    {
        //[Column("paperQuestion_id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaperQuestionId{ get; set; }

        //[Column("paper_id")]
        public int PaperId { get; set; }

        //[Column("question_id")]
        public int QuestionId { get; set; }

        public virtual Paper Paper { get; set; }
        public virtual Question Question { get; set; }
    }
}
