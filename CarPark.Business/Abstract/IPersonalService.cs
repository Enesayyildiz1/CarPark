using CarPark.Core.Models;
using CarPark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Business.Abstract
{
  public  interface IPersonalService
    {
        GetManyResult<Personal> GetAll();
    }
}
