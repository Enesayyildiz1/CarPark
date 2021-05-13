using CarPark.Core.Repository.Abstract;
using CarPark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.DataAccess.Abstract
{
    public interface IPersonalDal:IRepository<Personal>
    {
        List<Personal> GetPersonalsWithRoles();
    }
}
