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

        private readonly CrowdFundingTeam4DBContext _db;
        
         
        public FundableService(CrowdFundingTeam4DBContext dbContext)
        {
            _db = dbContext;
        }

        public Project ReadProjectFund(int ProjectId, decimal Fund)
        {
            throw new NotImplementedException();
        }

        
        List<FundingPackage> IFundable.ReadProject(int ProjectId)
        {
            throw new NotImplementedException();
        }


        public Project ReadProject (int ProjectId, Project project)
        {
            var dbProject = _db.Project.Find(ProjectId);
            if (dbProject == null) throw new KeyNotFoundException();
            dbProject.Name = project.Name;
            dbProject.Trending = project.Trending;
            dbProject.FundPackage = project.FundPackage;
            dbProject.Category = project.Category;

            object p = _db.SaveChanges();
            return dbProject;


        }

               


        public List<FundingPackage> ReadFundingPackeages(int projectId)
        {
            var FundingPackage = from FundingPackage in _db.Project
                                  orderby FundingPackage.Count descending
                                  select FundingPackage;

        }

       
    }
}
