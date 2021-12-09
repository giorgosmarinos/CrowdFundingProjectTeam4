using System.Collections.Generic;
using System.Threading.Tasks;
using CruwdFundingProjectTeam4.DTOs;
using CruwdFundingProjectTeam4.DTOs.Simplify;

namespace CruwdFundingProjectTeam4.Interfaces
{
    public interface IUserAPIService
    {
        // Get
        Task<UserDTO> GetUser(int id, bool IncludeCreatedProjects, bool IncludeFundedProjects, bool IncludeFundPackages);
        Task<List<UserSimplifyDTO>> GetAllUsers();
        Task<List<UserDTO>> SearchUser(string firstName, string LastName, bool IncludeCreatedProjects, bool IncludeFundedProjects, bool IncludeFundPackages);

        Task<ProjectDTO> GetProject(int id, bool IncludeCreator, bool IncludeBackers, bool IncludeFundingPackages, bool IncludeStatusUpdates);
        Task<List<ProjectSimplifyDTO>> GetAllProjects();

        Task<StatusUpdateDTO> GetStatusUpdate(int id);
        Task<List<StatusUpdateSimplifyDTO>> GetAllStatusUpdates();

        Task<FundingPackageDTO> GetFundingPackage(int id, bool IncludeUser = false);
        Task<List<FundingPackageSimplifyDTO>> GetAllFundingPackages();

        // Post
        Task<UserDTO> PostUser(UserDTO userDto);
        Task<ProjectDTO> PostProject(ProjectDTO projectDto);
        Task<FundingPackageDTO> PostFundingPackage(FundingPackageDTO fundingPackageDto);
        Task<StatusUpdateDTO> PostStatusUpdate(StatusUpdateDTO statusUpdateDTO);
        Task<UserDTO> Fund(int userId, int FundingPackageId);
    }
}
