using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessObjects
{
    //[Table("grade")]
    public class Grade
    {
        //create table grade( grade_id uniqueidentifier primary key, section_id uniqueidentifier FOREIGN KEY REFERENCES [section](section_id), participant_id uniqueidentifier FOREIGN KEY REFERENCES [user](user_id), grade Decimal submited_date Datetime);
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("grade_id")]
        public int GradeId { get; set; }


        //[Column("section_id")]
        public int SectionId { get; set; }


        //[Column("user_id")]
        public int UserId { get; set; }

        [Required]
        //[Column("score")]
        public double Score { get; set; }

        public DateTime SubmitedDate { get; set; }

        public virtual Section Section { get; set; }
        public virtual User User { get; set; }
    }
}
