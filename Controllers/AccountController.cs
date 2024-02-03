using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using game_collection.Models;

namespace game_collection.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        
        public AccountController(UserManager<IdentityUser> userManager){
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegisterViewModel model)
        {
            if(!ModelState.IsValid) return View(model);

            // Create the user
            var newUser = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email
            };

           // save the user info and the hashed password to the database
           var result =  await this.userManager.CreateAsync(newUser, model.Password);
           if(result.Succeeded)
            return Redirect("/Account/Login");
           
           else
           {
            foreach(var error in result.Errors)
            {
                if(error.Description.Contains("Email")) ModelState.AddModelError("Email", error.Description);
                if(error.Description.Contains("Username")) ModelState.AddModelError("Username", error.Description);
                if(error.Description.Contains("Password")) ModelState.AddModelError("Password", error.Description);
                if(error.Description.Contains("ConfirmPassword")) ModelState.AddModelError("ConfirmPassword", error.Description);
            }
                    
            return View();
           }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

    }
}