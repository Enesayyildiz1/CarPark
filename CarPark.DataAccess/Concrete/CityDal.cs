using CarPark.Core.Settings;
using CarPark.DataAccess.Abstract;
using CarPark.DataAccess.Context;
using CarPark.DataAccess.Repository;
using CarPark.Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.DataAccess.Concrete
{
    public class CityDal:MongoRepositoryBase<City> ,ICityDal
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<City> _collection;



        public CityDal(IOptions<MongoSettings> settings) : base(settings)
        {

            _context = new MongoDbContext(settings);
            _collection = _context.GetCollection<City>();
        }
    }
}
