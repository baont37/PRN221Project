using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class UserAnswer
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserAnswerId { get; set; }

        public int AnswerId { get; set; }

        public int SectionId { get; set; }
        public bool Selected { get; set; }
        public int UserId { get; set; }

        public virtual Section Section { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual User User { get; set; }
    }

}
