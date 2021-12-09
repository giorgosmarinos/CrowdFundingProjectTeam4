using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruwdFundingProjectTeam4.DTOs
{
    public class StatusUpdateDTO
    {
        public int StatusUpdateId { get; set; }
        public string Description { get; set; }
        public DateTime StatusTime { get; set; }
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
    }
}
