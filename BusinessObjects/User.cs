using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class User
    {
        //create table [user]( user_id uniqueidentifier primary key, uid varchar(255) not null, role varchar(100), email varchar(255), first_name varchar(255), last_name varchar(255), avt_url text )

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Uid { get; set; }

        public int Role { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string FirstName { get; set; }

        [StringLength(255)]
        public string LastName { get; set; }

        public string AvtUrl { get; set; }
    }
}
