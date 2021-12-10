using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundingProjectTeam4.Interfaces;
using CrowdFundingProjectTeam4.Model;
using CrowdFundingProjectTeam4MVC.Controllers;

namespace CrowdFundingProjectTeam4MVC.Controllers
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