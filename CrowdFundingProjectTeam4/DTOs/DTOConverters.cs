
using CrowdFundingProjectTeam4.Model;
using CruwdFundingProjectTeam4.DTOs.Simplify;
using CruwdFundingProjectTeam4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruwdFundingProjectTeam4.DTOs
{
    public static class DTOConverters
    {

        // User Converts
        public static UserDTO Convert(this User user)
        {
            var userDto = new UserDTO()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth
            };

            if (!(userDto.CreatedProject is  null))
            {
                userDto.CreatedProject = user.CreatedProject.Select(project => project.ConvertToBase()).ToList();
            }

            if (!(userDto.FundedProject is  null))
            {
                userDto.FundedProject = user.FundedProject.Select(project => project.Project.ConvertToBase()).ToList();
            }

            if (!(userDto.AssignedFundingPackages is null))
            {
                userDto.AssignedFundingPackages = user.AssignedFundingPackages.Select(fundedPackages => fundedPackages.FundingPackage.ConvertToBase()).ToList();
            }

            if (userDto == null) return null;
            return userDto;

        }

        public static UserSimplifyDTO ConvertToBase(this User user)
        {
            return new UserSimplifyDTO()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth
            };
        }

        // Projects Converts
        public static ProjectDTO Convert(this Project project)
        {
            var projectDto = new ProjectDTO()
            {
                ProjectId = project.ProjectId,
                Title = project.Title,
                Description = project.Description,
                MoneyGoal = project.MoneyGoal,
                CurrentBalance = project.CurrentBalance,
                DueDate = project.DueDate,
                UserId = project.ProjectCreator.UserId,
                UserFirstName = project.ProjectCreator.FirstName,
                UserLastName = project.ProjectCreator.LastName

            };

            if (!(projectDto.ListofFundingPackages is null))
            {
                projectDto.ListofFundingPackages = project.ListofFundingPackages
                    .Select(fpackage => fpackage.ConvertToBase()).ToList();
            }

            if (!(projectDto.ListofStatusUpdates is null))
            {
                projectDto.ListofStatusUpdates = project.ListofStatusUpdates
                    .Select(status => status.Convert()).ToList();
            }

            if (!(projectDto.ListofBackers is null) )
            {
                projectDto.ListofBackers = project.ListofBackers.Select(userProject => userProject.User.ConvertToBase()).ToList();
            }

            if (projectDto == null) return null;
            return projectDto;
        }

        public static ProjectSimplifyDTO ConvertToBase(this Project project)
        {
            return new ProjectSimplifyDTO()
            {
                ProjectId = project.ProjectId,
                Title = project.Title,
                Description = project.Description,
                MoneyGoal = project.MoneyGoal,
                DueDate = project.DueDate,
                CurrentBalance = project.CurrentBalance
            };
        }

        //Funding Package Converts
        public static FundingPackageDTO Convert(this FundingPackage fundingPackage)
        {
            var fpackage = new FundingPackageDTO()
            {
                FundingPackageId = fundingPackage.FundingPackageId,
                Value = fundingPackage.Value,
                Reward = fundingPackage.Reward,
                ProjectId = fundingPackage.ProjectId,
                ProjectName = fundingPackage.OwnedByProject.Title
            };

            if (!(fundingPackage.AssignToUser is null))
            {
                fpackage.AssignToUser = fundingPackage.AssignToUser.Select(ufp => ufp.User.ConvertToBase()).ToList();

            }

            if (fpackage == null) return null;

            return fpackage;
        }

        public static FundingPackageSimplifyDTO ConvertToBase(this FundingPackage fundingPackage)
        {

            return new FundingPackageSimplifyDTO()
            {
                FundingPackageId = fundingPackage.FundingPackageId,
                Value = fundingPackage.Value,
                Reward = fundingPackage.Reward
            };

        }

        //Status Update Converts

        public static StatusUpdateDTO Convert(this StatusUpdate statusUpdate)
        {

            var dto = new StatusUpdateDTO()
            {
                StatusUpdateId = statusUpdate.StatusUpdateId,
                Description = statusUpdate.Description,
                StatusTime = statusUpdate.StatusTime,
                ProjectId = statusUpdate.ProjectId,
                ProjectTitle = statusUpdate.Project.Title
            };

            return dto;
        }

        public static StatusUpdateSimplifyDTO ConvertToBase(this StatusUpdate statusUpdate)
        {

            return new StatusUpdateSimplifyDTO()
            {
                StatusUpdateId = statusUpdate.StatusUpdateId,
                Description = statusUpdate.Description,
                StatusTime = statusUpdate.StatusTime
            };
        }
    }
}
