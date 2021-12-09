using CruwdFundingProjectTeam4.DTOs.Simplify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruwdFundingProjectTeam4.DTOs
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal MoneyGoal { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime DueDate { get; set; }

        public int? UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public List<UserSimplifyDTO> ListofBackers { get; set; }
        public List<FundingPackageSimplifyDTO> ListofFundingPackages { get; set; }
        public List<StatusUpdateDTO> ListofStatusUpdates { get; set; }

        public ProjectDTO()
        {
            ListofBackers = new List<UserSimplifyDTO>();
            ListofFundingPackages = new List<FundingPackageSimplifyDTO>();
            ListofStatusUpdates = new List<StatusUpdateDTO>();
        }
    }
}
