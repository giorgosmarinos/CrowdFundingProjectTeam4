using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruwdFundingProjectTeam4.DTOs;
using CruwdFundingProjectTeam4.Interfaces;
using CruwdFundingProjectTeam4.DTOs.Simplify;

namespace CrowdFundingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIServices : ControllerBase
    {
        private IUserAPIService _service;

        public UserAPIServices(IUserAPIService service)
        {
            _service = service;
        }

        // Get - User
        [HttpGet, Route("Users/")]
        public async Task<List<UserSimplifyDTO>> GetAllUsers()
        {
            var dto = await _service.GetAllUsers();
            return dto;
        }

        [HttpGet, Route("Users/{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id, bool IncludeCreatedProjects = false, bool IncludeFundedProjects = false, bool IncludeFundPackages = false)
        {
            var dto = await _service.GetUser(id, IncludeCreatedProjects, IncludeFundedProjects, IncludeFundPackages);
            if (dto == null) return NotFound("The book Id is invalid or the book has been removed.");
            return Ok(dto);
        }

        [HttpGet, Route("Users/Search/")]
        public async Task<ActionResult<List<UserDTO>>> SearchUser(string firstName, string lastName, bool IncludeCreatedProjects = true, bool IncludeFundedProjects = false, bool IncludeFundPackages = false)
        {
            var dto = await _service.SearchUser(firstName, lastName, IncludeCreatedProjects, IncludeFundedProjects, IncludeFundPackages);
            return dto;
        }

        //Get - Project
        [HttpGet, Route("Project/")]
        public async Task<List<ProjectSimplifyDTO>> GetAllProjects()
        {
            var dto = await _service.GetAllProjects();
            return dto;
        }


        [HttpGet, Route("Projects/{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProject(int id, bool IncludeCreator = true, bool IncludeBackers = false, bool IncludeFundingPackages = false, bool IncludeStatusUpdates = false)
        {
            var dto = await _service.GetProject(id, IncludeCreator, IncludeBackers, IncludeFundingPackages, IncludeStatusUpdates);
            if (dto == null) return NotFound("The book Id is invalid or the book has been removed.");
            return Ok(dto);
        }

        //Get - StatusUpdates
        [HttpGet, Route("StatusUpdate/{id}")]
        public async Task<ActionResult<StatusUpdateDTO>> GetStatusUpdate(int id)
        {
            var dto = await _service.GetStatusUpdate(id);
            if (dto == null) return NotFound("The book Id is invalid or the book has been removed.");
            return Ok(dto);
        }

        [HttpGet, Route("StatusUpdate/")]
        public async Task<List<StatusUpdateSimplifyDTO>> GetAllStatusUpdate()
        {
            var dto = await _service.GetAllStatusUpdates();
            return dto;
        }

        // Get - FundingPackages
        [HttpGet, Route("FindingPackages/{id}")]
        public async Task<ActionResult<FundingPackageDTO>> GetFundingPackages(int id, bool IncludeUser)
        {
            var dto = await _service.GetFundingPackage(id, IncludeUser);
            if (dto == null) return NotFound("The book Id is invalid or the book has been removed.");
            return Ok(dto);
        }

        [HttpGet, Route("FindingPackages/")]
        public async Task<ActionResult<FundingPackageDTO>> GetAllFundingPackages()
        {
            var dto = await _service.GetAllFundingPackages();
            if (dto == null) return NotFound("The book Id is invalid or the book has been removed.");
            return Ok(dto);
        }

        [HttpPost, Route("User/Create")]
        public async Task<ActionResult<UserDTO>> PostUser(UserDTO user)
        {
            UserDTO result = await _service.PostUser(user);
            if (result == null) return NotFound("The specified author Id is invalid or the author has been removed. Could not create book.");
            return Ok(result);
        }

        [HttpPost, Route("Project/Create")]
        public async Task<ActionResult<ProjectDTO>> PostProject(ProjectDTO project)
        {
            ProjectDTO result = await _service.PostProject(project);
            if (result == null) return NotFound("The specified author Id is invalid or the author has been removed. Could not create book.");
            return Ok(result);
        }

        [HttpPost, Route("FundingPackage/Create")]
        public async Task<ActionResult<FundingPackageDTO>> PostFundingPackage(FundingPackageDTO fpackage)
        {
            FundingPackageDTO result = await _service.PostFundingPackage(fpackage);
            if (result == null) return NotFound("The specified author Id is invalid or the author has been removed. Could not create book.");
            return Ok(result);
        }

        [HttpPost, Route("StatusUpdate/Create")]
        public async Task<ActionResult<StatusUpdateDTO>> PostStatusUpdate(StatusUpdateDTO status)
        {
            StatusUpdateDTO result = await _service.PostStatusUpdate(status);
            if (result == null) return NotFound("The specified author Id is invalid or the author has been removed. Could not create book.");
            return Ok(result);
        }

        [HttpPost, Route("User/Fund")]
        public async Task<ActionResult<UserDTO>> Fund(int userId, int fundingPackageId)
        {
            UserDTO result = await _service.Fund(userId, fundingPackageId);
            if (result == null) return NotFound("test");
            return Ok(result);
        }


    }
}
