using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace game_collection.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        
        public AccountController(UserManager<IdentityUser> userManager){
            this.userManager = userManager;
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}