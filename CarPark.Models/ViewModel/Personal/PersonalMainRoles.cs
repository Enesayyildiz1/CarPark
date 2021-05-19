using AspNetCore.Identity.MongoDbCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Models.ViewModel.Personal
{
    public class PersonalMainRoles
    {
        public List<MongoIdentityRole> Roles { get; set; }
        public List<PersonalRoles> PersonalRoleList { get; set; }
    }

    public class PersonalRoles
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
