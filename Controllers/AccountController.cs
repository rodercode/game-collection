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
        public IActionResult Registration()
        {
            return View();
        }
    }
}