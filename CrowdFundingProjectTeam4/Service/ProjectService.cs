using CrowdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Service
{
    public class ProjectService: ProjectService
    {
        private readonly CrowdFundingTeam4DBContext dbContext;

        public ProjectService(CrowdFundingTeam4DBContext adbContext)
        {
            _db = dbContext;
        }

        public Project UpdateProject(int ProjectId, Project project)
        {
            var dbProject = _db.Project.Find(ProjectId);
            if (dbProject == null) throw new KeyNotFoundException();
            dbProject.Title = project.Title;
            dbProject.Description = project.Description;
            dbProject.MoneyGoal = project.MoneyGoal;
            dbProject.CurrentBalance = project.CurrentBalance;
            dbProject.DueDate = project.DueDate;
            dbProject.MinFund = project.MinFund;
            dbProject.MaxFund = project.MaxFund;

            _db.SaveChanges();
            return dbProject;

        }

        public bool DeleteProject(int id)
        {
            var dbProject = _db.Project.Find(id);
            if (dbProject == null) return false;
            _db.Project.Remove(dbProject);
            return _db.SaveChanges() == 1;
        }
    }
}
