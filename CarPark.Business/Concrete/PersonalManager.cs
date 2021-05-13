using CarPark.Business.Abstract;
using CarPark.Core.Models;
using CarPark.DataAccess.Abstract;
using CarPark.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Business.Concrete
{
    public class PersonalManager : IPersonalService
    {
        private IPersonalDal _personalDal;

        public PersonalManager(IPersonalDal personalDal)
        {
            _personalDal = personalDal;
        }

        public GetManyResult<Personal> GetAll()
        {
            var listOfPersonal=_personalDal.GetAll();
            return listOfPersonal;
        }
    }
}
