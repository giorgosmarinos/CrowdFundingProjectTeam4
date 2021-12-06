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
        public Project UpdateProject(int id);
        public Project DeleteProject(int id);
    }
}