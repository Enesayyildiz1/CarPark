using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Entities.Concrete
{
    [CollectionName("Personal")]
    public class Personal : MongoIdentityUser
    {
        public Personal()
        {
            CreatedDate = DateTime.Now;
            Status = 1;
        }
      
        public string Password { get; set; }
        
        public PersonalContact PersonalContact { get; set; }
        public List<Address> Addresses { get; set; }
        public short Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
