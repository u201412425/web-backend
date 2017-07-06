using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DoggyStyleWS.Models;
using DoggyStyleWS.ViewModel;
using DoggyStyleWS.ViewModel.ShelterViewModel;

namespace DoggyStyleWS.Controllers
{
    public class shelterController : BaseController
    {
        // GET: shelter
        public GenericObjectVM<List<PetShelterJson>> Get()
        {
            var responseBody = new GenericObjectVM<List<PetShelterJson>>();
            List<PetShelterJson> lstUser = context.User.Where(x=>x.Type == 2).Select(x=> new PetShelterJson {
                PetShelterId = x.UserId,
                Name = x.Name,
                Phone = x.Phone,
                Description = x.Description,
                Capacity = x.Capacity.Value,
                AviableCapacity = x.AviableCapacity.Value,
                State = x.State,
            }).ToList();
            responseBody.Message = "Correcto";
            responseBody.Result = lstUser;
            return responseBody;
        }
        public GenericObjectVM<PetShelterJson> Get(int id)
        {
            var responseBody = new GenericObjectVM<PetShelterJson>();
            try
            {
                PetShelterJson user = context.User.Where(x => x.UserId == id).Select(x => new PetShelterJson
                {
                    PetShelterId = x.UserId,
                    Name = x.Name,
                    Phone = x.Phone,
                    Description = x.Description,
                    Capacity = x.Capacity.Value,
                    AviableCapacity = x.AviableCapacity.Value,
                    State = x.State,
                }).First(); ;
                responseBody.Message = "Correcto";
                responseBody.Result = user;
                return responseBody;
            }
            catch (Exception)
            {

                responseBody.Code = (int)HttpStatusCode.InternalServerError;
                responseBody.Message = "Exception";
                return responseBody;
            }

        }
    }
}