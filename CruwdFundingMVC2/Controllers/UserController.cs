
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CruwdFundingProjectTeam4.Interfaces;
using CruwdFundingProjectTeam4.Model;
using CruwdFundingMVC2.Controllers;

namespace CruwdFundingMVC2.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            User user = _service.ReadUser(5);
            return View(user);
        }

    }
}
