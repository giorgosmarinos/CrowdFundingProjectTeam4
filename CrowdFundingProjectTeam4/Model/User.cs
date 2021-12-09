using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Model
{
    public class User
    {   
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }


        public virtual List<UserFundingPackage> AssignedFundingPackages { get; set; }
        public List<Project> CreatedProject { get; set; }
        public List<UserProject> FundedProject { get; set; }

        public User()
        {
            AssignedFundingPackages = new List<UserFundingPackage>();
            CreatedProject = new List<Project>();
            FundedProject =new  List<UserProject>();
        }
    }
}

