using CrowdFundingProjectTeam4.Model;
using CruwdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Service
{
    public interface IStatusService
    {
        bool DeleteProjectStatus(int id);
        StatusUpdate UpdateProjectStatus(int StatusUpdateId, StatusUpdate statusupdate);
    }
}