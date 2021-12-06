using CruwdFundingProjectTeam4.DTOs;
using CruwdFundingProjectTeam4.DTOs.Simplify;
using CruwdFundingProjectTeam4.Interfaces;
using CruwdFundingProjectTeam4.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruwdFundingProjectTeam4.Services
{
    public class UserService : IUserService, IUserAPIService
    {
        //TODO - Create Validations
        //TODO - Create Comments
        //TODO - CHECK
        private readonly CrowdFundingTeam4DBContext _cruwdFundingDBContext;

        public UserService(CrowdFundingTeam4DBContext adbContext)
        {
            _cruwdFundingDBContext = adbContext;
        }

        // CRUD - CREATE
        public List<FundingPackage> CreateFundPackage(FundingPackage fundpackage, int projectid)
        {
            Project projectFound = _cruwdFundingDBContext.Project.Find(projectid);
            projectFound.ListofFundingPackages.Add(fundpackage);
            _cruwdFundingDBContext.SaveChanges();
            return null;
        }

        public void CreateProject(Project project, int userid)
        {
            User creator = _cruwdFundingDBContext.User.Find(userid);
            //Project.Add(project);
            creator.CreatedProject.Add(project);
            _cruwdFundingDBContext.SaveChanges();
        }

        public StatusUpdate CreateStatusUpdate(StatusUpdate statusupdate, int projectid)
        {
            var projectFound = _cruwdFundingDBContext.Project.Find(projectid);
            projectFound.ListofStatusUpdates.Add(statusupdate);
            _cruwdFundingDBContext.SaveChanges();
            return null;
        }

        public void CreateUser(User user)
        {
            _cruwdFundingDBContext.User.Add(user);
            try
            {
                _cruwdFundingDBContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            };
        }

        public void Fund(UserProject userFundsProject, UserFundingPackage userGetFundingPackage)
        {

            _cruwdFundingDBContext.UserProject.Add(userFundsProject);
            _cruwdFundingDBContext.UserFundingPackage.Add(userGetFundingPackage);

            _cruwdFundingDBContext.SaveChanges();

        }

        // CRUD - READ

        public List<Project> ReadCreatedProjects(int userid)
        {
            List<Project> list = _cruwdFundingDBContext.Project.Where(p => p.UserId == userid).ToList();
            return list;
        }

        public List<Project> ReadFundedProjects(int userid)
        {

            var list = _cruwdFundingDBContext.UserProject
                .Where(up => up.User.UserId == userid)
                .Select(up => up.Project).ToList();
            return list;

        }

        public User ReadUser(int id)
        {
            //var query = _cruwdFundingDBContext.User.Where(user => user.UserId == id);
            User user = _cruwdFundingDBContext.User.Where(u => u.UserId == id)
                .Include(u => u.CreatedProject)
                .Include(u => u.AssignedFundingPackages).ThenInclude(fp => fp.FundingPackage)
                .Include(u => u.FundedProject).ThenInclude(p => p.Project)
                .SingleOrDefault();
            return user;
        }

        public List<User> ReadUser()
        {
            List<User> ListUsers = _cruwdFundingDBContext.User.ToList();
            return ListUsers;
        }

    }
}
