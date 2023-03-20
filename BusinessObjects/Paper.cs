using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Paper
    {
        //create table paper( paper_id uniqueidentifier primary key, created_by uniqueidentifier FOREIGN KEY REFERENCES [user](user_id), name varchar(255) not null, created_at varchar(255), ); 
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       // [Column("paper_id")]
        public int PaperId { get; set; }

        //[Column("user_id")]

        public int UserId { get; set; }
   
        [Required]
        [StringLength(255)]
        //[Column("name")]
        public string Name { get; set; }

        //[Column("create_at")]
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }


    }
}
