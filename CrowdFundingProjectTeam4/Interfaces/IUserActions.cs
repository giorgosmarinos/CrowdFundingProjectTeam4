using CrowdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4.Interfaces
{
    public interface IUserService
    {
        // CRUD - READ
        List<Project> ReadCreatedProjects(int userid);
        List<Project> ReadFundedProjects(int userid);
        User ReadUser(int id);
        List<User> ReadUser();
        List<FundingPackage> ReadFundingPackages(int projectid);

        // CRUD - CREATE
        List<FundingPackage> CreateFundPackage(FundingPackage fundpackage, int projectid);
        StatusUpdate CreateStatusUpdate(StatusUpdate statusupdate, int projectid);
        void CreateProject(Project project, int userid);
        void CreateUser(User user);
        void Fund(UserProject userFundsProject, UserFundingPackage userGetFundingPackage);
    }
}
