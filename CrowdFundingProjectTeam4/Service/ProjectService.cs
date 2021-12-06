using CrowdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Service
{
    public class ProjectService : IProjectService  
    {
        private readonly CrowdFundingTeam4DBContext _db;

        public ProjectService(CrowdFundingTeam4DBContext dbContext)
        {
            _db = dbContext;
        }

        /*
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

        } */

        public bool DeleteProject(int id)
        {
            var dbProject = _db.Project.Find(id);
            if (dbProject == null) return false;
            _db.Project.Remove(dbProject);
            return _db.SaveChanges() == 1;
        }

        //create also read project in order to test the connection with MVC 
        public Project ReadProject(int id)
        {
            return _db.Project.Find(id);
        }

        //create also read project in order to test the connection with MVC 
        public List<Project> ReadProject(int pageCount, int pageSize)
        {
            if (pageCount <= 0) pageCount = 1;
            if (pageSize <= 0 || pageSize > 20) pageSize = 20;
            return _db.Project
                .Skip((pageCount - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Project UpdateProject(int projectId, Project project)
        {
            var dbProject = _db.Project.Find(projectId);
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

    }
}
