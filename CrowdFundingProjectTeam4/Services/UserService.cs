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


        // API 
        // TODO - FIX FundedPackages it does not work
        // GET Methods
        public async Task<List<UserSimplifyDTO>> GetAllUsers()
        {
            var query = _cruwdFundingDBContext.User;
            return await query.Select(u => u.ConvertToBase()).ToListAsync();
        }

        public async Task<UserDTO> GetUser(int id, bool IncludeCreatedProjects, bool IncludeFundedProjects, bool IncludeFundPackages)
        {
            var query = _cruwdFundingDBContext.User.Where(user => user.UserId == id);

            if (IncludeCreatedProjects)
            {
                query = query.Include(user => user.CreatedProject);
            }

            if (IncludeFundedProjects)
            {
                query = query.Include(user => user.FundedProject).ThenInclude(up => up.Project);
            }

            if (IncludeFundPackages)
            {
                query = query.Include(user => user.AssignedFundingPackages).ThenInclude(fp => fp.FundingPackage);
            }

            var userAns = await query.SingleOrDefaultAsync();
            if (userAns == null) return null;

            return userAns.Convert();
        }

        public async Task<List<ProjectSimplifyDTO>> GetAllProjects()
        {
            var query = _cruwdFundingDBContext.Project;
            return await query.Select(p => p.ConvertToBase()).ToListAsync();
        }

        public async Task<ProjectDTO> GetProject(int id, bool IncludeCreator, bool IncludeBackers, bool IncludeFundingPackages, bool IncludeStatusUpdates)
        {
            var query = _cruwdFundingDBContext.Project.Where(p => p.ProjectId == id);

            if (IncludeCreator)
            {
                query = query.Include(pc => pc.ProjectCreator);
            }

            if (IncludeBackers)
            {
                query = query.Include(lb => lb.ListofBackers).ThenInclude(up => up.User);
            }

            if (IncludeFundingPackages)
            {
                query = query.Include(fp => fp.ListofFundingPackages);
            }

            if (IncludeStatusUpdates)
            {
                query = query.Include(su => su.ListofStatusUpdates);
            }

            var projectAns = await query.SingleOrDefaultAsync();
            if (projectAns == null) return null;

            return projectAns.Convert();
        }

        public async Task<StatusUpdateDTO> GetStatusUpdate(int id)
        {
            var dto = await _cruwdFundingDBContext.StatusUpdate.Where(su => su.StatusUpdateId == id).Include(p => p.Project).SingleOrDefaultAsync();
            if (dto == null) return null;
            return dto.Convert();
        }

        public async Task<List<StatusUpdateSimplifyDTO>> GetAllStatusUpdates()
        {
            var query = _cruwdFundingDBContext.StatusUpdate;
            return await query.Select(su => su.ConvertToBase()).ToListAsync();
        }

        public async Task<FundingPackageDTO> GetFundingPackage(int id, bool IncludeUser)
        {
            IQueryable<FundingPackage> query = _cruwdFundingDBContext.FundingPackage.Where(fp => fp.FundingPackageId == id).Include(p => p.OwnedByProject);

            if (IncludeUser)
            {
                query = query.Include(fp => fp.AssignToUser).ThenInclude(ufp => ufp.User);
            }

            var userAns = await query.SingleOrDefaultAsync();
            if (userAns == null) return null;

            return userAns.Convert();

        }

        public async Task<List<FundingPackageSimplifyDTO>> GetAllFundingPackages()
        {
            var query = _cruwdFundingDBContext.FundingPackage;
            return await query.Select(fp => fp.ConvertToBase()).ToListAsync();

        }

        public async Task<List<UserDTO>> SearchUser(string firstName, string lastName, bool IncludeCreatedProjects, bool IncludeFundedProjects, bool IncludeFundPackages)
        {
            IQueryable<User> query = _cruwdFundingDBContext.User;

            if (firstName != null)
            {
                query = query.Where(u => u.FirstName.ToLower().Contains(firstName.ToLower()));
            }

            if (lastName != null)
            {
                query = query.Where(u => u.LastName.ToLower().Contains(lastName.ToLower()));
            }

            if (IncludeCreatedProjects)
            {
                query = query.Include(user => user.CreatedProject);
            }

            if (IncludeFundedProjects)
            {
                query = query.Include(user => user.FundedProject).ThenInclude(up => up.Project);
            }

            if (IncludeFundPackages)
            {
                query = query.Include(user => user.AssignedFundingPackages);
            }


            return await query.Select(u => u.Convert()).ToListAsync();
        }


        // TODO - And Post Methods for User , Project , Status Updates , Funding Package
        public async Task<UserDTO> PostUser(UserDTO userDto)
        {
            User newUser = new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                DateOfBirth = userDto.DateOfBirth,
                Email = userDto.Email
            };
            _cruwdFundingDBContext.Add(newUser);
            await _cruwdFundingDBContext.SaveChangesAsync();
            return newUser.Convert();
        }

        public async Task<ProjectDTO> PostProject(ProjectDTO projectDto)
        {
            User projectCreator = await _cruwdFundingDBContext.User.SingleOrDefaultAsync(u => u.UserId == projectDto.UserId);
            if (projectCreator == null) return null;

            Project project = new Project()
            {
                Title = projectDto.Title,
                Description = projectDto.Description,
                MoneyGoal = projectDto.MoneyGoal,
                CurrentBalance = projectDto.CurrentBalance,
                DueDate = projectDto.DueDate,
                ProjectCreator = projectCreator,
                UserId = projectCreator.UserId
            };

            _cruwdFundingDBContext.Project.Add(project);
            await _cruwdFundingDBContext.SaveChangesAsync();

            return project.Convert(); ;
        }

        public async Task<FundingPackageDTO> PostFundingPackage(FundingPackageDTO fundingPackageDto)
        {
            Project project = await _cruwdFundingDBContext.Project.SingleOrDefaultAsync(p => p.ProjectId == fundingPackageDto.ProjectId);
            if (project == null) return null;

            FundingPackage fundPackage = new FundingPackage()
            {
                Reward = fundingPackageDto.Reward,
                Value = fundingPackageDto.Value,
                OwnedByProject = project,
                ProjectId = project.ProjectId
            };

            _cruwdFundingDBContext.Add(fundPackage);
            await _cruwdFundingDBContext.SaveChangesAsync();
            return fundPackage.Convert();
        }

        public async Task<StatusUpdateDTO> PostStatusUpdate(StatusUpdateDTO statusUpdateDTO)
        {
            Project project = await _cruwdFundingDBContext.Project.SingleOrDefaultAsync(p => p.ProjectId == statusUpdateDTO.ProjectId);
            if (project == null) return null;

            StatusUpdate status = new StatusUpdate()
            {
                Description = statusUpdateDTO.Description,
                StatusTime = statusUpdateDTO.StatusTime,
                Project = project,
                ProjectId = project.ProjectId
            };

            _cruwdFundingDBContext.Add(status);
            await _cruwdFundingDBContext.SaveChangesAsync();
            return status.Convert();
        }

        public async Task<UserDTO> Fund(int userId, int fundingPackageId)
        {
            var user = await _cruwdFundingDBContext.User.Where(u => u.UserId == userId).SingleOrDefaultAsync();
            if (user is null) return null;

            var fpackage = await _cruwdFundingDBContext.FundingPackage.Where(fp => fp.FundingPackageId == fundingPackageId).SingleOrDefaultAsync();
            if (fpackage is null) return null;

            var project = await _cruwdFundingDBContext.Project.Where(p => p.ProjectId == fpackage.ProjectId).SingleOrDefaultAsync();
            if (project is null) return null;



            UserProject fundedProject = new UserProject()
            {
                Project = project,
                User = user
            };


            await _cruwdFundingDBContext.UserProject.AddAsync(fundedProject);

            UserFundingPackage assignFundPackage = new UserFundingPackage()
            {
                FundingPackage = fpackage,
                User = user
            };

            await _cruwdFundingDBContext.UserFundingPackage.AddAsync(assignFundPackage);

            await _cruwdFundingDBContext.SaveChangesAsync();
            user = await _cruwdFundingDBContext.User.Where(u => u.UserId == userId).Include(u => u.FundedProject).ThenInclude(p => p.Project).Include(u => u.AssignedFundingPackages).SingleOrDefaultAsync();

            return user.Convert();
        }
    }
}
