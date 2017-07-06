using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoggyStyleWS.Models
{
    public class PetShelterLocalJson
    {
        public Int32? PetShelterLocalId { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Description { get; set; }
        public String State { get; set; }
        public Int32 PetShelterId { get; set; }
    }
}