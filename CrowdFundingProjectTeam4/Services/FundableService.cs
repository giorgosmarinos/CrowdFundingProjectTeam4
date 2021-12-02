using CrowdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Services
{
    public class FundableService : IFundable
    {

        private readonly CrowdFundingTeam4DBContext _dbContext;
        private object[] projectId;
        private object _db;

        public CrowdFundingTeam4DBContext Db => _dbContext;

        public FundableService(CrowdFundingTeam4DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Project ChangeProjectFund(int ProjectId, decimal Fund)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public Project ReadProject(int ProjectId)
        {
            throw new NotImplementedException();
        }

        public Project ReadProject(int ProjectId, Project project)
        {
            throw new NotImplementedException();
        }

        List<FundingPackage> IFundable.ReadProject(int ProjectId)
        {
            throw new NotImplementedException();
        }


        public Project ReadProject (int ProjetcId, Project project)
        {
            var dbProject = _dbContext.Project.Find(projectId);
            if (dbProject == null) throw new KeyNotFoundException();
            dbProject.Name = project.Name;
            dbProject.Trending = project.Trending;
            dbProject.FundPackage = project.FundPackage;
            dbProject.Category = project.Category;

            object p = _db.SaveChanges();
            return dbProject;


        }

        public void CreateFunding(FundingPackage fundingPackage)
        {
            _dbContext.FundingPackage.Add(fundingPackage);
            try { _dbContext.SaveChanges();}
            catch { }

        }

        public List<FundingPackage> GetFundingPackages(int projectId)
        {
            throw new NotImplementedException();
        }

        public List<FundingPackage> ReadProject()
        {
            _dbContext.FundingPackage.ToList();
        }


        public List<FundingPackage> GetFundingPackeages(int fundingPackage)
        {
            var FundingPackage = from FundingPackage in Db.Project
                                  orderby FundingPackage.Count ascending
                                  select FundingPackage;

        }

       
    }
}
