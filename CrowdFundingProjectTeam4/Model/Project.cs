using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Model
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
        public int UserId { get; set; }
        public virtual List<UserProject> ListofBackers { get; set; } //check if virtual keyword is necessary 
        public virtual List<FundingPackage> ListofFundingPackages { get; set; } //check if virtual keyword is necessary 
        public virtual List<StatusUpdate> ListofStatusUpdates { get; set; } //check if virtual keyword is necessary 
        public object Name { get; internal set; }
        public object Category { get; internal set; }
        public object Trending { get; internal set; }
        public object FundPackage { get; internal set; }
        public Category 
        
}
