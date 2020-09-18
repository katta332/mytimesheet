using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using AngularProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace AngularProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserDetailsRepository _context;

        public IConfiguration Configuration { get; }
        public AccountController(IUserDetailsRepository context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                return Content("valid");
            }
            return View("Login");

    }

        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login(string username, string password)
        //{
         //   return Content($"Hello {username}");
        //}   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
