using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    class CarPark : BaseModel
    {
        
        public string Name { get; set; }
        public string[] PhoneNumbers { get; set; }
        public Address Address { get; set; }
        public string[] Personels { get; set; }
        public string WebSite { get; set; }
        public string[] EmailAddresses { get; set; }
        public List<WorkingDay> WorkingDays { get; set; }
        public List<FloorInformation> Floors { get; set; }
    }
}
