using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundableMvc.Models
{
    public class FundingController
    {
        public List<FundingController> Project { get; set; }
        public List<int> ProjectIds { get; set; }
        

        public FundingController(SelectList funding)
        {
            Funding = funding;
        }
    }

    public class FundingPackage
    {
        public int Funding { get; set; }
        public string Text { get; set; }
    }

   
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
