using CrowdFundingProjectTeam4.Model;
using CrowdFundingProjectTeam4.Service;
using CrowdFundingProjectTeam4MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        /*
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
        */

        private readonly CrowdFundingTeam4DBContext _context;

        public ProjectController(CrowdFundingTeam4DBContext context)
        {
            _context = context;
        }

        // GET:Project
        public async Task<IActionResult> Index(string projectGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> projectQuery = from m in _context.Project
                                            orderby m.Genre
                                            select m.Genre;

            var projects = from m in _context.Project
                         select m;

            if (!string.IsNullOrEmpty(projectGenre))
            {
                projects = projects.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(projectGenre))
            {
                projects = projects.Where(x => x.Genre == projectGenre);
            }

            var projectVM = new ProjectGenreViewModel
            {
                Genres = new SelectList(await projectQuery.Distinct().ToListAsync()),
                Projects = await projects.ToListAsync()
            };

            return View(projectVM); //View(await _context.Project.ToListAsync());
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
    }
}
