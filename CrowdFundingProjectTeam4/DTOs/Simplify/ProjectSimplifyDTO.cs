using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruwdFundingProjectTeam4.DTOs.Simplify
{
    public class ProjectSimplifyDTO
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal MoneyGoal { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime DueDate { get; set; }
    }
}
