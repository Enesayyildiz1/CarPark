using CarPark.Entities.Concrete;
using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly MongoClient client;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            client = new MongoClient("mongodb+srv://enesayyildiz:yozgatordu@carparkcluster.bmiv4.mongodb.net/CarParkDB?retryWrites=true&w=majority");
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            //var say_Hello_value = _localizer["Say_Hello"];


            //var cultureInfo = CultureInfo.GetCultureInfo("en-US");

            //Thread.CurrentThread.CurrentCulture = cultureInfo;
            //Thread.CurrentThread.CurrentUICulture = cultureInfo;
            
            //var say_Hello_value2 = _localizer["Say_Hello"];
            //var customer = new Customer()
            //{
            //    Id = 1,
            //    Name = "Enes",
            //    Surname = "Ayyıldız",
            //    Age = 18
            //};
            //var customer2 = new Customer()
            //{
            //    Id = 2,
            //    Name = "Ege",
            //    Surname = "Gökmen",
            //    Age = 35
            //};
            //_logger.LogError("Customer  da bir hata oluştu {@customer}",customer2);

           
            //var database = client.GetDatabase("CarParkDB");
            //var jsonString = System.IO.File.ReadAllText("cities.json");
            //var citiesModel = JsonConvert.DeserializeObject<List<Cities>>(jsonString);
            //var collection = database.GetCollection<City>("City");
            //foreach (var item in citiesModel)
            //{
            //    var city = new City()
            //    {
            //        Id = ObjectId.GenerateNewId(),
            //        Latitude = item.Latitude,
            //        Logitude = item.Longtitude,
            //        Name = item.Name,
            //        Plate = item.Plate,
            //        Counties = new List<County>()



            //    };
            //    foreach (var county in item.Counties)
            //    {
            //        city.Counties.Add(new County()
            //        {
            //            Id = ObjectId.GenerateNewId(),
            //            Name = county

            //        });
            //    }
            //    collection.InsertOne(city);
            //}

            //var test = new Test()
            //{
            //    _Id = ObjectId.GenerateNewId(),
            //    NameSurname = "Enes Ayyıldız",
            //    Age = 19,
            //    AddressList = new List<Entities.Concrete.Address>()
            //    {
            //        new Entities.Concrete.Address
            //    {
            //        Title="Ev Adresim",
            //        Description="Zeytinburnu"
            //        },
            //           new Entities.Concrete.Address
            //    {
            //        Title="İş Adresim",
            //        Description="Levent 4"
            //    }

            //    }

            //};
            //collection.InsertOne(test);
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
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
