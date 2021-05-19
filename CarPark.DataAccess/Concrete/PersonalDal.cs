using CarPark.Core.Settings;
using CarPark.DataAccess.Abstract;
using CarPark.DataAccess.Context;
using CarPark.DataAccess.Repository;
using CarPark.Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarPark.DataAccess.Concrete
{
    public class PersonalDal : MongoRepositoryBase<Personal>, IPersonalDal
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<Personal> _collection;


       
        public PersonalDal(IOptions<MongoSettings> settings):base(settings)
        {
          
            _context = new MongoDbContext(settings); 
            _collection = _context.GetCollection<Personal>();
        }


        public List<Personal> GetPersonalsWithRoles()
        {
            var personals = _collection.AsQueryable().Where(a => a.Password =="1345").ToList();
            return personals;
        }

        public List<Personal> GetRoles(string id)
        {
            var roles = _collection.AsQueryable().Where(x => x.Id.ToString() == id).ToList();
            return roles;
        }
    }
}
