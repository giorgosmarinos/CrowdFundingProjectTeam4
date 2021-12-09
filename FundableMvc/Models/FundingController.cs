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

   
       
        

        
        
    
}
