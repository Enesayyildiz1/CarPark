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
        {   var result = new GetOneResult<PersonalMainRoles>();
            try
            {
            var roles = _roleManager.Roles != null ? _roleManager.Roles.ToList() : null;
            
            var personal =await _personalDal.GetByIdAsync(id,"guid");

            var personalRoles = personal != null && personal.Entity != null && personal.Entity.Roles != null ?
                personal.Entity.Roles.Select(x => new PersonalRoles
                {
                    Id = x.ToString(),
                    Name = roles.FirstOrDefault(y => y.Id == x).Name
                }).ToList() : null;


         
            result.Entity = new PersonalMainRoles
            {
                Roles = roles,
                PersonalRoleList = personalRoles,


            };
            result.Success = true;
            }
            catch (Exception ex)
            {

                result.Entity = null;
                result.Success = false;
            }
           
            return result;
        }

        public async Task<GetOneResult<Personal>> UpdatePersonalRoles(string personalId, string[] personalRoleList)
        {
            var personal = await _personalDal.GetByIdAsync(personalId, "guid");
            var roles = personalRoleList.Select(x => new Guid(x)).ToList();
            personal.Entity.Roles = null;
            personal.Entity.Roles = roles;
            var result = await _personalDal.ReplaceOneAsync(personal.Entity, personalId, "guid");
            result.Message = $"{personal.Entity.Name}{personal.Entity.Surname} adlı personelin rol güncellenmesi gerçekleşti.";
            result.Success = true;
            return result;
        }
    }
}
