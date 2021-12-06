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
        
        public Project ReadCategory(int ProjectId, Category category);

        public Project ReadProjectFund(int ProjectId);
                      
        Project ReadProject(int ProjetcId, Project project);
        
        List<FundingPackage> ReadProject(int ProjectId);
        
        List<FundingPackage> ReadFundingPackeages(int projectId);
    }
}
