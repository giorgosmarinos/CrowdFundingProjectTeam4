using CrowdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Services
{
    interface IFundable
    {
        

        public Project GetCategory(int ProjectId, Category category);

        public Project ReadProjectFund(int ProjectId, decimal Fund);

        List<FundingPackage> GetFundingPackages(int projectId);
        
        Project ReadProject(int ProjetcId, Project project);
        
        List<FundingPackage> ReadProject(int ProjectId);
    }
}
