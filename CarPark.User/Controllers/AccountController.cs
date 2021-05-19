using CarPark.Entities.Concrete;
using CarPark.Models.RequestModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarPark.User.Controllers;
using AspNetCore.Identity.MongoDbCore.Models;

namespace CarPark.User.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Personal> _userManager;
        private readonly SignInManager<Personal> _signInManager;
        private readonly RoleManager<MongoIdentityRole> _mongoIdentityRole;

        public AccountController(UserManager<Personal> userManager, SignInManager<Personal> signInManager, RoleManager<MongoIdentityRole> mongoIdentityRole)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mongoIdentityRole = mongoIdentityRole;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterCreateModel createModel, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new Personal
                {
                    UserName = createModel.UserName,
                    Email = createModel.Email,
                    PhoneNumber = "0536265895"


                };
                var result = await _userManager.CreateAsync(user, createModel.Password);


                if (result.Succeeded)
                {
                    var role = new MongoIdentityRole
                    {
                        Name = "admin",
                        NormalizedName = "ADMIN"

                    };

                  


                    var resultRole = await _mongoIdentityRole.CreateAsync(role);

                    await _userManager.AddToRoleAsync(user, "admin");

                    return RedirectToAction("Login");

                }
            }

            return View(createModel);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();


        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()

        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
