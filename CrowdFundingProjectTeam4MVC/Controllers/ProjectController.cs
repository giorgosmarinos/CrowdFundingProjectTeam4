using CrowdFundingProjectTeam4.Model;
using CrowdFundingProjectTeam4.Service;
using CrowdFundingProjectTeam4MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace CrowdFundingProjectTeam4MVC.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService; 
        }

        public IActionResult Index()
        {
            List<Project> projects = projectService.ReadProject(1, 10);
            return View(projects);
        }

    }
}
