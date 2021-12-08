using CruwdFundingProjectTeam4.DTOs.Simplify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruwdFundingProjectTeam4.DTOs
{
    public class FundingPackageDTO
    {
        public int FundingPackageId { get; set; }
        public decimal Value { get; set; }
        public string Reward { get; set; }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public List<UserSimplifyDTO> AssignToUser { get; set; }

        public FundingPackageDTO()
        {
            AssignToUser = new List<UserSimplifyDTO>();
        }
    }
}
