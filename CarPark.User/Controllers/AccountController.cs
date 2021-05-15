using CarPark.Models.RequestModel.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Register(RegisterCreateModel createModel,string returnUrl=null)
        {
            if (ModelState.IsValid)
            {

            }
            return View(createModel);
        }
    }
}
