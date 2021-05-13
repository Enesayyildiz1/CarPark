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
        private readonly IRepository<Personal> _personalRepository;

        public UserController(IStringLocalizer<UserController> localizer, IRepository<Personal> personalRepository)
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
            var personal1 = _personalRepository.InsertMany(new List<Personal>
            {
                new Personal
            {
                UserName = "Ordulu",
                Email = "enes@gmail.com",
                Password = "1234124",
                CreatedDate = DateTime.Now,


            },
            new Personal
            {
                UserName = "Gaziantepli",
                Email = "emre@gmail.com",
                Password = "12341223424",
                CreatedDate = DateTime.Now
            }
            }

               


            );
            return View();

    }



}
}
