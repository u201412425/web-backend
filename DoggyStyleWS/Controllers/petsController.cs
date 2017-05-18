using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DoggyStyleWS.Models;
using DoggyStyleWS.ViewModel.PetViewModel;
using DoggyStyleWS.ViewModel;

namespace DoggyStyleWS.Controllers
{
    public class PetsController : BaseController
    {
        [Route("api/{id:int}/Pets")]
        public GenericObjectVM<List<PetJson>> Get([FromUri]int id)
        {
            var response = new GenericObjectVM<List<PetJson>>();
            try
            {
                var listPets = context.Pet.Where(x => x.UserId == id).Select(x=> new PetJson {
                    PetId= x.PetId,
                    UserId= x.UserId,
                    NamePet= x.NamePet,
                    Description= x.Description,
                    State = x.State,
                    Type = x.Type,
                    SpecialFeatures = x.SpecialFeatures,
                    PetShelterId = x.PetShelterId,
                    Age = x.Age,
                    ImagenUrl = x.Description
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
        public GenericObjectVM<PetJson> Gets([FromUri]int id)
        {
            var response = new GenericObjectVM<PetJson>();
            try
            {
                var listPets = context.Pet.Where(x=>x.PetId == id).ToList().Select(x => new PetJson
                {
                    PetId = x.PetId,
                    UserId = x.UserId,
                    NamePet = x.NamePet,
                    Description = x.Description,
                    State = x.State,
                    Type = x.Type,
                    SpecialFeatures = x.SpecialFeatures,
                    PetShelterId = x.PetShelterId,
                    Age = x.Age,
                    ImagenUrl = x.Description
                }).ToList();
                response.Code = (int)HttpStatusCode.OK;
                response.Message = "Successful";
                response.Result = listPets.FirstOrDefault();
                return response;
            }
            catch (Exception)
            {

                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = "Exception";
                return response;
            }

        }

        public GenericObjectVM<Pet> Post([FromBody]CreatePetViewModel model)
        {
            var response = new GenericObjectVM<Pet>();
            try
            {
                Pet pet = new Pet();
                pet.UserId = model.UserId;
                pet.NamePet = model.NamePet;
                pet.Description = model.Description;
                pet.Type = model.Type;
                pet.SpecialFeatures = model.SpecialFeatures;
                pet.Age = model.Age;
                pet.PetShelterId = model.PetShelterId;
                pet.State = "ACT";
                context.Pet.Add(pet);
                context.SaveChanges();
                response.Code = (int)HttpStatusCode.OK;
                response.Result = pet;
                response.Message = "Successful Create";
                return response;
            }
            catch (Exception ex)
            {

                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.ToString();
                return response;
            }

        }
        public GenericObjectVM<String> Put([FromUri] int id, [FromBody]UpdatePetViewModel model)
        {
            var response = new GenericObjectVM<String>();
            try
            {
                Pet pet = null;
                if (id == 0)
                {
                    pet = new Pet();
                    context.Pet.Add(pet);
                    pet.ImagenUrl = "";
                }
                else
                    pet = context.Pet.Find(id);
                if (pet == null)
                {
                    response.Code = (int)HttpStatusCode.NotFound;
                    response.Result = null;
                    response.Message = "Pet Not Found";
                }
                pet.UserId = model.UserId;
                pet.NamePet = model.NamePet;
                pet.Description = model.Description;
                pet.Type = model.Type;
                pet.SpecialFeatures = model.SpecialFeatures;
                pet.Age = model.Age;
                pet.PetShelterId = model.PetShelterId;
                pet.State = model.State;
      
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

        public GenericObjectVM<String> Delete(int id)
        {
            var responseBody = new GenericObjectVM<String>();
            Pet user = context.Pet.Find(id);
            context.Pet.Remove(user);
            context.SaveChanges();
            responseBody.Message = "Correcto";
            responseBody.Result = "Eliminado";
            return responseBody;
        }
        
    }
}