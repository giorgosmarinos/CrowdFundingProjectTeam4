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

        Project ReadCategory(int ProjectId, Category category);

        Project ReadProjectFund(int ProjectId);

        Project ReadProject(int ProjetcId, Project project);

        List<Project> ReadProject(int ProjectId);

        List<Project> ReadFundingPackages(int projectId);

    }
}
