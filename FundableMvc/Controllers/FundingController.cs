using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundableMvc.Controllers
{ 
    public class FundingController : Controller
    {

        private readonly ΙFundableService fundableService;

            public FundingController(IFundableService fundableService)
            {
                this.fundableService = fundableService;
            }


            public IActionResult Index()
            {
            List<Project> projects = _projectService.ReadProject()
               .Where(project => project.Name.Contains(Name))
               .ToList();
            return View();
            }
        
    }
    
         public ActionResult ShowFunding(int id)
          {

        int projectId = 2;

        List<FundingPackage> fundingPackages = _fundableService
            .ReadFunding(1, 10).
            Select(Product => new FundingPackage()
            {
                Funding = projectId,
                Text = projectId.Name

            }).ToList();

         private readonly CrowdFundingTeam4DBContext _context;

         public ProjectController(CrowdFundingTeam4DBContext context)
         {
        _context = context;
         }


    public async Task<IActionResult> Index(string Fund)
    {

        IQueryable<string> projectQuery = from m in _context.Project
                                          orderby m.Fund
                                          select m.Fund;

        var projects = from m in _context.Project
                       select m;
    }
}







