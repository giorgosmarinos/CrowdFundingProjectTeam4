using CrowdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruwdFundingProjectTeam4.Model
{
    public class UserFundingPackage
    {
        public int UserFundingPackageId { get; set; }
        public User User { get; set; }
        public FundingPackage FundingPackage { get; set; }
    }
}
