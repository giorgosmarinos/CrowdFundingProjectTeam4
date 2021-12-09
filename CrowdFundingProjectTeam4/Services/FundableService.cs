using CrowdFundingProjectTeam4.Model;
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
            dbProject.Name = project.Name;
            dbProject.MaxFund = project.MaxFund;
            dbProject.MinFund = project.MinFund;
            dbProject.FundPackage = project.FundPackage;
            dbProject.Category = project.Category;

            object p = _db.SaveChanges();
            return dbProject;


        }




        public List<Project> ReadProject(int projectId)
        {
            var Project = from MaxFund in _db.Project
                                 orderby MaxFund.Count descending
                                 select MaxFund;

        }

        public Project ReadProjectFund(int ProjectId)
        {
            throw new NotImplementedException();
        }
    }
}
