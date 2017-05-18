using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoggyStyleWS.Models
{
    public class PetJson
    {
        public int PetId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string NamePet { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public int Type { get; set; }
        public string SpecialFeatures { get; set; }
        public Nullable<int> PetShelterId { get; set; }
        public int Age { get; set; }
        public string ImagenUrl { get; set; }
    }
}