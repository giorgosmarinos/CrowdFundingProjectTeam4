using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruwdFundingProjectTeam4.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal MoneyGoal { get; set; }
        public decimal CurrentBalance { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public decimal MinFund { get; set; }
        public decimal MaxFund { get; set; }


        public int? UserId { get; set; }
        public User ProjectCreator { get; set; }

        public List<UserProject> ListofBackers { get; set; }
        public List<FundingPackage> ListofFundingPackages { get; set; } 
        public List<StatusUpdate> ListofStatusUpdates { get; set; }

        public Project()
        {
            ListofBackers = new List<UserProject>();
            ListofFundingPackages = new List<FundingPackage>();
            ListofStatusUpdates = new List<StatusUpdate>();
        }
    }
}
