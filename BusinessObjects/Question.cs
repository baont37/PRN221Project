using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace BusinessObjects
{
    public class Question
    {
        //create table question( question_id uniqueidentifier primary key, created_by uniqueidentifier FOREIGN KEY REFERENCES [user](user_id), [text] text, isMultiChoice bit, level int, type varchar(255) ); 

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("question_id")]
        public int QuestionId { get; set; }

        [Required]
        //[Column("user_id")]
        public int UserId { get; set; }

        [Required]
        //[Column("text")]
        public string Text { get; set; }

        [Required]
        //[Column("isMultiChoice")]
        public bool IsMultiChoice { get; set; }

        [Required]
       //[Column("lever")]
        public int Lever { get; set; }

        //[Column("type")]
        public string Type { get; set; }

        public virtual User User { get; set; }
    }
}
