using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var client = new MongoClient("mongodb+srv://enesayyildiz:yozgatordu@carparkcluster.bmiv4.mongodb.net/CarParkDB?retryWrites=true&w=majority");
            var database = client.GetDatabase("CarParkDB");
            var collection = database.GetCollection<Test>("Test");

            var test = new Test()
            {
                _Id = ObjectId.GenerateNewId(),
                NameSurname = "Enes Ayyıldız",
                Age = 19,
                AddressList = new List<Address>()
                {
                    new Address
                {
                    Title="Ev Adresim",
                    Description="Zeytinburnu"
                    },
                       new Address
                {
                    Title="İş Adresim",
                    Description="Levent 4"
                }

                }

            };
            collection.InsertOne(test);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
