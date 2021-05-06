using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CarPark.Entities.Concrete
{
    public class WorkingDay : BaseModel
    {
       
        public List<Translation> Translation { get; set; }
        public List<WorkingHour> WorkingHours { get; set; }
    }
}