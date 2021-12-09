using CrowdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Service
{
    public class StatusService : IStatusService
    {
        private readonly CrowdFundingTeam4DBContext _db;

        public StatusService(CrowdFundingTeam4DBContext dbContext)
        {
            _db = dbContext;
        }

        public bool DeleteProjectStatus(int id)
        {
            var dbProjectStatus = _db.StatusUpdate.Find(id);
            if (dbProjectStatus == null) return false;
            _db.StatusUpdate.Remove(dbProjectStatus);
            return _db.SaveChanges() == 1;
        }

        public StatusUpdate UpdateProjectStatus(int StatusUpdateId, StatusUpdate statusupdate)
        {
            var dbProjectStatus = _db.StatusUpdate.Find(StatusUpdateId);
            //mallon h epomenh grammh kwdika den xreiazetai 
            if (dbProjectStatus == null) throw new KeyNotFoundException();
            dbProjectStatus.ProjectId = statusupdate.ProjectId;
            dbProjectStatus.Description = statusupdate.Description;
            dbProjectStatus.StatusTime = statusupdate.StatusTime;

            _db.SaveChanges();
            return dbProjectStatus;

        }

       
    }
}