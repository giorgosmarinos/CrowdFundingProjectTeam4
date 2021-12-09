using CrowdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Service
{
    public interface IProjectService
    {
        Project UpdateProject(int id, Project project);  //edw opws kai se ola ta interfaces mou evgaze error opote psaxnontas to 
                                                         //katalava oti prepei na min valw mprosta to "public"  https://stackoverflow.com/questions/10154664/the-modifier-public-is-not-valid-for-this-item-on-an-interface-method/10154687
        bool DeleteProject(int id);
        List<Project> ReadProject(int pageCount, int pageSize);
        Project ReadProject(int id);
    }
}