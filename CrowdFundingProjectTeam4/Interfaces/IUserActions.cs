using CruwdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruwdFundingProjectTeam4.Interfaces
{
    public interface IUserService
    {
        // CRUD - READ
        public List<Project> ReadCreatedProjects(int userid);
        public List<Project> ReadFundedProjects(int userid);
        public User ReadUser(int id);
        public List<User> ReadUser();

        // CRUD - CREATE
        public List<FundingPackage> CreateFundPackage(FundingPackage fundpackage, int projectid);
        public StatusUpdate CreateStatusUpdate(StatusUpdate statusupdate, int projectid);
        public void CreateProject(Project project, int userid);
        public void CreateUser(User user);
        public void Fund(UserProject userFundsProject, UserFundingPackage userGetFundingPackage);
    }
}
