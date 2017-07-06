using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoggyStyleWS.Models
{
    public class AdoptionRequestJson
    {

        public Int32 AdoptionRequestId { get; set; }
        public String FullName { get; set; }
        public String Description { get; set; }
    }
}