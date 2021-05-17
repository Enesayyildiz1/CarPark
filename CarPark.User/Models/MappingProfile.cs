using AutoMapper;
using CarPark.Entities.Concrete;
using CarPark.Models.ViewModel.Personal;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.User.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Personal, PersonalProfileInfo>().ReverseMap();
            
        }
    }
}
