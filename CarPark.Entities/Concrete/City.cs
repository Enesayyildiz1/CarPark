using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    public class City : BaseModel
    {
      
        public string Name { get; set; }
        public string Plate { get; set; }
        public string Latitude { get; set; }
        public string Logitude { get; set; }
        public List<County> Counties { get; set; }
    }
}
