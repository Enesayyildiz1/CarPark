using CarPark.Core.Models;
using CarPark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Business.Abstract
{
    public interface ICityService
    {
        Task<GetManyResult<City>> GetAllCitiesAsync();
    }
}
