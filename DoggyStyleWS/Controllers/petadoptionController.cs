using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DoggyStyleWS.Models;
using DoggyStyleWS.ViewModel.PetAdoptionViewModel;
using DoggyStyleWS.ViewModel;


namespace DoggyStyleWS.Controllers
{
    public class petadoptionController : BaseController
    {
        // GET: petshelter
        public GenericObjectVM<List<PetJson>> Get([FromUri]int id)
        {
            var response = new GenericObjectVM<List<PetJson>>();
            try
            {
                var listPets = context.PetAdoption.Where(x => x.Pet.UserId == id && x.State.Equals("ACT")).Select(x => new PetJson
                {
                    PetId = x.PetId,
                    UserId = x.Pet.UserId,
                    NamePet = x.Pet.NamePet,
                    Description = x.Pet.Description,
                    State = x.State,
                    Type = x.Pet.Type,
                    SpecialFeatures = x.Pet.SpecialFeatures,
                    Age = x.Pet.Age,
                    ImagenUrl = x.Pet.ImagenUrl
                }).ToList();
                response.Code = (int)HttpStatusCode.OK;
                response.Message = "Successful";
                response.Result = listPets;
                return response;
            }
            catch (Exception)
            {

                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = "Exception";
                return response;
            }
        }

        public GenericObjectVM<List<PetJson>> Get()
        {
            var response = new GenericObjectVM<List<PetJson>>();
            try
            {
                var listPets = context.PetAdoption.Where(x=>x.State.Equals("ACT")).Select(x => new PetJson
                {
                    PetId = x.PetId,
                    UserId = x.Pet.UserId,
                    NamePet = x.Pet.NamePet,
                    Description = x.Pet.Description,
                    State = x.State,
                    Type = x.Pet.Type,
                    SpecialFeatures = x.Pet.SpecialFeatures,
                    Age = x.Pet.Age,
                    ImagenUrl = x.Pet.ImagenUrl
                }).ToList();
                response.Code = (int)HttpStatusCode.OK;
                response.Message = "Successful";
                response.Result = listPets;
                return response;
            }
            catch (Exception)
            {

                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = "Exception";
                return response;
            }
        }
        [HttpPost]
        public GenericObjectVM<String> Post(CreatePetAdoptionViewModel model)
        {
            var responseBody = new GenericObjectVM<String>();
            try
            {
             
                return responseBody;

            }
            catch (Exception ex)
            {


            }
            return responseBody;
        }


        public GenericObjectVM<String> Put([FromUri] int id, [FromBody]CreatePetAdoptionViewModel model)
        {
            var response = new GenericObjectVM<String>();
            try
            {
                PetAdoption petAdoption = null;
                Pet pet = context.Pet.Find(model.PetId);
                
                if (id == 0)
                {
                    petAdoption = new PetAdoption();
                    context.PetAdoption.Add(petAdoption);
                    petAdoption.State = "ACT";
                    pet.State = "ADO";
                }
                if(model.State=="INA")
                {
                    pet.State = "ACT";
                }
                else
                {
                    pet.State = "ADO";
                }
                petAdoption.PetId = model.PetId;
                petAdoption.Description = "Albergue";
                petAdoption.CreatioDate = DateTime.Now;
                context.SaveChanges();
                response.Code = (int)HttpStatusCode.OK;
                response.Result = "Completo";
                response.Message = "Successful Update";
                return response;
            }
            catch (Exception ex)
            {

                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.ToString();
                response.Message = "Faltal Error";
                return response;
            }

        }
    }
}