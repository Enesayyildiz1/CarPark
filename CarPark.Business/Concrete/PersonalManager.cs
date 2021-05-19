using AspNetCore.Identity.MongoDbCore.Models;
using CarPark.Business.Abstract;
using CarPark.Core.Models;
using CarPark.DataAccess.Abstract;
using CarPark.Entities.Concrete;
using CarPark.Models.ViewModel.Personal;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Business.Concrete
{
    public class PersonalManager : IPersonalService
    {
        private IPersonalDal _personalDal;
        private readonly RoleManager<MongoIdentityRole> _roleManager;


        public PersonalManager(IPersonalDal personalDal, RoleManager<MongoIdentityRole> roleManager)
        {
            _personalDal = personalDal;
            _roleManager = roleManager;
        }

        public GetManyResult<Personal> GetAll()
        {
            var listOfPersonal=_personalDal.GetAll();
            return listOfPersonal;
        }

        public async Task<GetOneResult<PersonalMainRoles>> GetPersonalRoles(string id)
        {
            var personal =await _personalDal.GetByIdAsync(id);
            var personalRoles = personal.Entity.Roles;
            var roles = _roleManager.Roles != null ? _roleManager.Roles.ToList() : null;
            return roles;
        }
    }
}
