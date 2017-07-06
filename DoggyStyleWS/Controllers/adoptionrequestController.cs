using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DoggyStyleWS.Models;
using DoggyStyleWS.ViewModel.AdoptionRequest;
using DoggyStyleWS.ViewModel;


namespace DoggyStyleWS.Controllers
{
    public class adoptionrequestController : BaseController
    {
        public GenericObjectVM<List<AdoptionRequestJson>> Get([FromUri]int id)
        {
            var response = new GenericObjectVM<List<AdoptionRequestJson>>();
            try
            {
                var listRequest = context.AdoptionRequest.Where(x => x.PetAdoption.PetId == id && x.State.Equals("ACT")).Select(x => new AdoptionRequestJson
                {
                    AdoptionRequestId = x.AdoptionRequestId,
                    Description = x.Description,
                    FullName = x.User.Name +" "+ x.User.LastName
                }).ToList();
                response.Code = (int)HttpStatusCode.OK;
                response.Message = "Successful";
                response.Result = listRequest;
                return response;
            }
            catch (Exception)
            {

                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = "Exception";
                return response;
            }
        }

        public GenericObjectVM<String> Put([FromUri] int id, [FromBody]CreateAdoptionRequestViewModel   model)
        {
            var response = new GenericObjectVM<String>();
            try
            {
                AdoptionRequest adoptionRequest = null;
                if (id == 0)
                {
                    adoptionRequest = new AdoptionRequest();
                    context.AdoptionRequest.Add(adoptionRequest);
                    adoptionRequest.UserId = model.UserId;
                    adoptionRequest.Description = model.Description;
                    PetAdoption petAdoption = context.PetAdoption.Where(x => x.PetId == model.PetId).FirstOrDefault();
                    adoptionRequest.PetIdAdoptionId = petAdoption.PetAdoptionId;
                    adoptionRequest.State = "ACT";
                    
                }
                else
                {
                    adoptionRequest = context.AdoptionRequest.Find(id);
                    PetAdoption petAdoption = context.PetAdoption.Find(adoptionRequest.PetIdAdoptionId);
                    petAdoption.State = "INA";

                    Pet pet = context.Pet.Find(petAdoption.PetId);
                    pet.UserId = adoptionRequest.UserId;
                    pet.State = "ACT";
                }
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