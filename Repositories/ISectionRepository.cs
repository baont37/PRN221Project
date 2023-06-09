﻿using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISectionRepository
    {
        SectionDTO Add(SectionDTO questionAndAnswer);

        List<SectionDTO> GetSectionsByUserId(int userId);
    }
}
