﻿using CrowdFundingProjectTeam4.Interfaces;
using CrowdFundingProjectTeam4.Service;
using CrowdFundingProjectTeam4.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingProjectTeam4MVC.Controllers
{
    public class FundingPackage : Controller
    {
        private readonly IUserService _service;

        public FundingPackage(IUserService service)
        {
            _service = service;
        }

        public IActionResult Index(int projectid)
        {
            projectid = 11;
            //_service.ReadProject(projectid);
            List<CrowdFundingProjectTeam4.Model.FundingPackage> listfpacks = _service.ReadFundingPackages(projectid);
            return View(listfpacks);
        }

        public IActionResult Create(int projectid)
        {

            CrowdFundingProjectTeam4.Model.FundingPackage fpack = new CrowdFundingProjectTeam4.Model.FundingPackage()
            {
                ProjectId = projectid
            };

            return View(fpack);
        }


        public IActionResult Fund(int fundingpackageId)
        {

            //UserProject userFundsProject, UserFundingPackage userGetFundingPackage
            User user = _service.ReadUser(5);
            //FundingPackage fpack = _service.ReadFundingPackage(fundingpackageId);
            //Project project = _service.ReadProject(fpack.ProjectId);

            //UserProject userFundsProject = new UserProject()
            //{
            //    User = user,
            //    Project = project
            //};

            //UserFundingPackage userGetFundingPackage = new UserFundingPackage()
            //{
            //    User = user,
            //    FundingPackage = fpack
            //};

            //_service.Fund(userFundsProject, userGetFundingPackage);

            return RedirectToAction("Index", "FundingPackage");
        }

        public IActionResult Done()
        {

            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public IActionResult Submit(CrowdFundingProjectTeam4.Model.FundingPackage fpack)
        {

            //Project project = _service.ReadProjects(fpack.ProjectId);
            _service.CreateFundPackage(fpack, fpack.ProjectId);

            return RedirectToAction("Create", new { fpack.ProjectId });
        }
    }
}