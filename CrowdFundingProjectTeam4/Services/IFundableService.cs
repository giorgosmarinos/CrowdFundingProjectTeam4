using CrowdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Services
{
    interface IFundableService
    {
        
        public Project ReadCategory(int ProjectId, Category category);

        public Project ReadProjectFund(int ProjectId);
                      
        Project ReadProject(int ProjetcId, Project project);
        
        List<FundingPackage> ReadProject(int ProjectId);
        
        List<FundingPackage> ReadFundingPackages(int projectId);

        
}
