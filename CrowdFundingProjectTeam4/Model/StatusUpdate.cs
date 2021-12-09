using CrowdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Model
{
    public class StatusUpdate
    {
        [Key]
        public int StatusUpdateId { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public DateTime StatusTime { get; set; }

        public Project Project { get; set; }
    }
}
