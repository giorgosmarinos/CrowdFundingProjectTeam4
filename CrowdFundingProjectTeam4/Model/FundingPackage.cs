using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Model
{
    public class FundingPackage
    {
        public int FundingPackageId { get; set; }
        public int Project { get; set; }
        public int ProjectId { get; set; }
        public decimal Value { get; set; }
        public string Reward { get; set; }
        public Project OwnedByProject { get; set; }
        public virtual List<UserFundingPackage> AssignToUser { get; set; }
    }
}
