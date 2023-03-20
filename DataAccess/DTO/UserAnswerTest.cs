using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class UserAnswerTest
    {
        public int SectionId { get; set; }
        public int UserId { get; set; }
        public List<UserAnswerDTO> UserAnswerDTOs { get; set; }

    }
}
