﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Model
{
    public class StatusUpdate
    {
        public int StatusUpdateId { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public DateTime StatusTime { get; set; }

    }
}
