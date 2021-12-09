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

        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,Title,Description,MoneyGoal,CurrentBalance,DueDate,MinFund,MaxFund,Genre,UserId")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        private bool ProjectExists(int projectId)
        {
            return _context.Project.Any(e => e.ProjectId == projectId);
        }

        // GET: Customer2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Customer2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Project
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Project.FindAsync(id);
            _context.Project.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Customer2/Fund/5
        public async Task<IActionResult> Fund(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Project
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
    }
}
