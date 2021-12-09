using CruwdFundingProjectTeam4.DTOs.Simplify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruwdFundingProjectTeam4.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public List<FundingPackageSimplifyDTO> AssignedFundingPackages { get; set; }
        public List<ProjectSimplifyDTO> CreatedProject { get; set; }
        public List<ProjectSimplifyDTO> FundedProject { get; set; }

        public UserDTO()
        {
            AssignedFundingPackages = new List<FundingPackageSimplifyDTO>();
            CreatedProject = new List<ProjectSimplifyDTO>();
            FundedProject = new List<ProjectSimplifyDTO>();
        }
    }
}
