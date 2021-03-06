﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoggyStyleWS.ViewModel.UserViewModel
{
    public class UpdateUserViewModel
    {

        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public Int32 Type { get; set; }
        public String Description { get; set; }
        public Int32? Capacity { get; set; }
        public Int32? AviableCapacity { get; set; }
    }
}