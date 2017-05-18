using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoggyStyleWS.Models
{
    public class UserJson
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public Nullable<int> PetShelter { get; set; }
        public string Phone { get; set; }
    }
}