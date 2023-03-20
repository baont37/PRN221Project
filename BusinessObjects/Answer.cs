using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Answer
    {
        //create table answer( answer_id uniqueidentifier primary key, question_id uniqueidentifier FOREIGN KEY REFERENCES question(question_id), [text] varchar(300), isCorrect bit ); 
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }

        public int QuestionId { get; set; }

        [Required]
        [StringLength(300)]
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        public virtual Question Question { get; set; }

    }
}
