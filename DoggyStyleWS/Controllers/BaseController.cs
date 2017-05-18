using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using DoggyStyleWS.Models;
namespace DoggyStyleWS.Controllers
{
    public class BaseController : ApiController
    {
        public DoggyStyleEntities context;
        private CargarDatosContext cargarDatosContext;
        public BaseController()
        {
            context = new DoggyStyleEntities();
        }
        public CargarDatosContext CargarDatosContext()
        {
            if (cargarDatosContext == null)
            {
                cargarDatosContext = new CargarDatosContext { context = context };
            }

            return cargarDatosContext;
        }

    }

    public class CargarDatosContext
    {
        public DoggyStyleEntities context { get; set; }
    }
}