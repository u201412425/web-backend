using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoggyStyleWS.ViewModel.PetViewModel
{
    public class UpdatePetViewModel
    {
        public Int32 UserId { get; set; }
        public String NamePet { get; set; }
        public String Description { get; set; }
        public Int32 Type { get; set; }
        public String SpecialFeatures { get; set; }
        public int Age { get; set; }
        public Int32? PetShelterId { get; set; } 
        public String State { get; set; }
    }
}