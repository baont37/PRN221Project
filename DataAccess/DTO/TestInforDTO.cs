﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class TestInforDTO
    {
        public int SectionId { get; set; }

        public string AccessKey { get; set; }

        public string Name { get; set; }

        public DateTime ActivatedAt { get; set; }

        public int TimeLimit { get; set; }
        public List<QuestionAndAnswerDTO> questionAndAnswerDTOs { get; set; }
    }
}
