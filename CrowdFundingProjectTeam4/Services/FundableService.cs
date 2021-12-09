using CrowdFundingProjectTeam4.Model;
using CruwdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Services
{
    public class FundableService : IFundableService
    {
        private readonly CrowdFundingTeam4DBContext _db;

        public FundableService(CrowdFundingTeam4DBContext dbContext)
        {
            _db = dbContext;
        }

        public Project ReadCategory(int ProjectId, Category category)
        {
            throw new NotImplementedException();
        }

        public List<Project> ReadFundingPackages(int projectId)
        {
            throw new NotImplementedException();
        }

        public Project ReadProject(int ProjectId, Project project)
        {
            var dbProject = _db.Project.Find(ProjectId);
            if (dbProject == null) throw new KeyNotFoundException();
            dbProject.Title = project.Title;
            dbProject.MaxFund = project.MaxFund;
            dbProject.MinFund = project.MinFund;
            dbProject.ListofFundingPackages = project.ListofFundingPackages;
            dbProject.Genre = project.Genre;

            object p = _db.SaveChanges();
            return dbProject;


        }

        public List<Project> ReadProject(int ProjectId)
        {
            throw new NotImplementedException();
        }




        //public List<Project> ReadProject(int projectId)
        //{
        //    var Project = from CurrentBalance in _db.Project
        //                         orderby CurrentBalance.Count descending
        //                         select CurrentBalance;
        //    return null;
        //}

        public Project ReadProjectFund(int ProjectId)
        {
            throw new NotImplementedException();
        }
    }
}
