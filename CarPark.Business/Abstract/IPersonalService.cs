using CarPark.Core.Models;
using CarPark.Entities.Concrete;
using CarPark.Models.ViewModel.Personal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Business.Abstract
{
  public  interface IPersonalService
    {
        GetManyResult<Personal> GetAll();
       Task< GetOneResult<PersonalMainRoles>> GetPersonalRoles(string id);
    }
}
