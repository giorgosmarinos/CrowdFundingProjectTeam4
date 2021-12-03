using CrowdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Service
{
    public class StatusService: StatusService
    {
        private readonly CrowdFundingTeam4DBContext dbContext;

        public StatusService(CrowdFundingTeam4DBContext adbContext)
        {
            _db = dbContext;
        }

        public StatusUpdate UpdateProjectStatus(int StatusUpdateId, StatusUpdate statusupdate)
        {
            var dbProjectStatus = _db.StatusUpdate.Find(StatusUpdateId);
            //mallon h epomenh grammh kwdika den xreiazetai 
            if (dbProjectStatus == null) throw new KeyNotFoundException(); 
            dbStatusUpdate.ProjectId = statusupdate.ProjectId
            dbStatusUpdate.Description = statusupdate.Description;
            dbStatusUpdate.StatusTime = statusupdate.StatusTime;

            _db.SaveChanges();
            return dbProjectStatus;

        }

        public bool DeleteStatusProject(int id)
        {
            var dbProjectStatus = _db.StatusUpdate.Find(id);
            if (dbProjectStatus == null) return false; 
            _db.Project.Remove(dbProjectStatus);
            return _db.SaveChanges() == 1;
        }
    }
}
