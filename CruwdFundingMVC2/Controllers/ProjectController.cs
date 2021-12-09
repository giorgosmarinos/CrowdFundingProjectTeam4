using CruwdFundingProjectTeam4.Interfaces;
using CruwdFundingProjectTeam4.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CruwdFundingMVC2.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IUserService _service;

        public ProjectController(IUserService service)
        {
            _service = service;
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {   // TODO - Make the thinking when the project is null OR not the required => return to Basic View else Proceed to CreatFundingPackage View
            if (project.Title == "" || project.MoneyGoal == 0m || project.DueDate == DateTime.MinValue)
            {
                return RedirectToAction("Index","User");
            }
            
            _service.CreateProject(project , 5);
            //_service.ReadProjectsByID();
            return RedirectToAction("Create", "FundingPackage", new { project.ProjectId });
        }
    }
}
