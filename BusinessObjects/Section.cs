using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Section
    {
        //create table [section] ( section_id uniqueidentifier primary key, access_key varchar(255), name varchar(255), paper_id uniqueidentifier FOREIGN KEY REFERENCES paper(paper_id), created_by uniqueidentifier FOREIGN KEY REFERENCES [user](user_id), activated_at Datetime default(now), time_limit Decimal )

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SectionId { get; set; }

        [Required]
        [StringLength(255)]
        public string AccessKey { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int PaperId { get; set; }

        /*[Required]
        public int UserId { get; set; }*/

        [Required]
        public DateTime ActivatedAt { get; set; }

        [Required]
        public int TimeLimit { get; set; }

        public virtual Paper Paper { get; set; }
        //public virtual User  User { get; set; }
    }
}
