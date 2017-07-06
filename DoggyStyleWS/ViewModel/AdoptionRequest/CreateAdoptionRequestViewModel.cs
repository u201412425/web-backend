using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoggyStyleWS.ViewModel.AdoptionRequest
{
    public class CreateAdoptionRequestViewModel
    {
        public Int32 AdoptionRequestId { get; set; }
        public Int32 UserId { get; set; }
        public Int32 PetId { get; set; }
        public String Description { get; set; }
        public String State { get; set; }
    }
}