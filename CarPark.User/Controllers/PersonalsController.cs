using AutoMapper;
using CarPark.Business.Abstract;
using CarPark.Business.Concrete;
using CarPark.Entities.Concrete;
using CarPark.Models.ViewModel.Personal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
   
    public class PersonalsController : Controller
    {
        private  IPersonalService _personalManager;
        private ICityService _cityService;
        private readonly IMapper _mapper;
        private UserManager<Personal> _userManager;

        public PersonalsController(IPersonalService personalManager, UserManager<Personal> userManager, ICityService cityService, IMapper mapper)
        {
            _personalManager = personalManager;
            _userManager = userManager;
            _cityService = cityService;
            _mapper = mapper;
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
           var list= _personalManager.GetAll();
            return View(list.Result);
        }
        public async Task<IActionResult> Settings()
        {
            var user =await _userManager.GetUserAsync(User);
            var cities =await _cityService.GetAllCitiesAsync();

            var personalInfo = _mapper.Map<PersonalProfileInfo>(user);
            personalInfo.Cities = cities.Result;
            return View(personalInfo);
        }
    }
}
