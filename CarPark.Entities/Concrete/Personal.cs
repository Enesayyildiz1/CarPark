using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    public class Personal : BaseModel
    {
     
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
        public PersonalContact PersonalContact { get; set; }
        public List<Address> Addresses { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
