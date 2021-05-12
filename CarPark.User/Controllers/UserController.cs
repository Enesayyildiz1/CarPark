using CarPark.Core.Repository.Abstract;
using CarPark.Entities.Concrete;
using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
    public class UserController : Controller
    {
        private readonly IStringLocalizer<UserController> _localizer;
        private readonly IRepository<Test> _personalRepository;

        public UserController(IStringLocalizer<UserController> localizer, IRepository<Test> personalRepository)
        {
            _localizer = localizer;
            _personalRepository = personalRepository;
        }

        public IActionResult Index()
        {
            var userInfo = _localizer["NameSurname"];

            

            


            var enUserInfo = _localizer["NameSurname"];



            return View();
        }
        public IActionResult Create()

        {
            var personal1 = _personalRepository.InsertOne(new Test
            { Age=19}
                


            );
            var personal2 = _personalRepository.InsertOne(new Test
            {
              Age=29

            });
            return View();
            
        }
      


    }
}
