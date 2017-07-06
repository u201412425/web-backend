using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoggyStyleWS.ViewModel.PetAdoptionViewModel
{
    public class CreatePetAdoptionViewModel
    {
        public Int32 PetId { get; set; }
        public String Description { get; set; }
        public String State { get; set; }
    }
}