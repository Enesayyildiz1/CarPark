using AutoMapper;
using CarPark.Business.Abstract;
using CarPark.Business.Concrete;
using CarPark.Entities.Concrete;
using CarPark.Models.ViewModel.Personal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
        private IWebHostEnvironment _env;

        public PersonalsController(IPersonalService personalManager, UserManager<Personal> userManager, ICityService cityService, IMapper mapper, IWebHostEnvironment env)
        {
            _personalManager = personalManager;
            _userManager = userManager;
            _cityService = cityService;
            _mapper = mapper;
            _env = env;
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
           var list= _personalManager.GetAll();
            return View(list.Result);
        }
        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            var user =await _userManager.GetUserAsync(User);
            var cities =await _cityService.GetAllCitiesAsync();
            user.ImageUrl = $"/Media/Personals/{user.ImageUrl}";

            var personalInfo = _mapper.Map<PersonalProfileInfo>(user);
            personalInfo.Cities = cities.Result;
            return View(personalInfo);
        }
        [HttpPost]
        public async Task<IActionResult> Settings(PersonalProfileInfo personalProfileInfo)
        {
            var user = _userManager.GetUserAsync(User).Result;
            string imgUrl = "";
            if (personalProfileInfo.Image!=null&&personalProfileInfo.Image.Length>0)
            {
                var path = Path.Combine(_env.WebRootPath, "Media/Personals/");
                var fileName = Guid.NewGuid().ToString()+"_"+personalProfileInfo.Image.FileName;

                var filepath = Path.Combine(path, fileName);
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    personalProfileInfo.Image.CopyTo(fileStream);
                    imgUrl = fileName;
                }
            }
            else
            {
                imgUrl = user.ImageUrl;
            }
            personalProfileInfo.UserName = user.UserName;
            personalProfileInfo.Email = user.Email;
            personalProfileInfo.ImageUrl = imgUrl;


            var personalModel = _mapper.Map(personalProfileInfo,user);
            var updated = await _userManager.UpdateAsync(personalModel);
            if (updated.Succeeded)      
                return Json(new { message = "Başarılı", success = true, personalModel = personalModel });
            
            else            
                return Json(new { message = "Başarısız", success = false, personalModel = personalModel });
            
        
        }
    }
}
