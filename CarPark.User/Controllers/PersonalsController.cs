using CarPark.Business.Abstract;
using CarPark.Business.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PersonalsController : Controller
    {
        private  IPersonalService _personalManager;

        public PersonalsController(IPersonalService personalManager)
        {
            _personalManager = personalManager;
        }

        public IActionResult Index()
        {
           var list= _personalManager.GetAll();
            return View(list.Result);
        }
    }
}
