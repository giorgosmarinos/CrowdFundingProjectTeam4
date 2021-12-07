using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundableMvc.Controllers
{
    public class FundingController : Controller
    {

        public class FundingController : Controller
        {
            private readonly IFundableService fundableService;

            public FundingController(IFundableService fundableService)
            {
                this.fundableService = fundableService;
            }


            public IActionResult Index()
            {
                return View();
            }
        }
    }
}
