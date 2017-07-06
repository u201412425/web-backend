using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DoggyStyleWS.Models;
using DoggyStyleWS.ViewModel.UserViewModel;
using DoggyStyleWS.ViewModel;

namespace DoggyStyleWS.Controllers
{
    public class UsersController : BaseController
    {
        public GenericObjectVM<List<User>> Get()
        {
            var responseBody = new GenericObjectVM<List<User>>();
            List<User> lstUser = context.User.ToList();
            responseBody.Message = "Correcto";
            responseBody.Result = lstUser;
            return responseBody;
        }
        public GenericObjectVM<User> Get(int id)
        {
            var responseBody = new GenericObjectVM<User>();
            try
            {
                User user = context.User.Find(id);
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
        [HttpPost]
        public GenericObjectVM<String> Post(CreateUserViewModel model)
        {
            var responseBody = new GenericObjectVM<String>();
            try
            {
                User user = new User();
                user.UserName = model.UserName;
                user.Password = model.Password;
                user.Email = model.Email;
                user.Type = model.Type;
                user.Name = model.Name;
                user.LastName = model.LastName;
                user.Address = model.Address;
                user.State = "ACT";
                user.Phone = model.Phone;
                context.User.Add(user);
                context.SaveChanges();
                return responseBody;
            
            }
            catch (Exception ex)
            {

             
            }
            return responseBody;
        }

        public GenericObjectVM<String> Put(int id,[FromBody]UpdateUserViewModel model)
        {
            var response = new GenericObjectVM<String>();
            try
            {


                User user = null;
                if (id == 0)
                {
                    user = new User();
                    context.User.Add(user);
                    user.State = "ACT";
                }
                else
                    user = context.User.Find(id);

                if (user == null)
                {
                    response.Code = (int)HttpStatusCode.NotFound;
                    response.Result = null;
                    response.Message = "User Not Found";
                    return response;
                }
                user.UserName = model.UserName;
                user.Password = model.Password;
                user.Email = model.Email;
                user.Name = model.Name;
                user.LastName = model.LastName;
                user.Address = model.Address;
                user.Phone = model.Phone;
                user.Type = model.Type;
                user.Description = model.Description; 
                user.Capacity = model.Capacity;
                user.AviableCapacity = model.AviableCapacity;
                context.SaveChanges();

                response.Code = (int)HttpStatusCode.OK;
                response.Result = "Correcto";
                response.Message = "Successful Create";
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
            User user = context.User.Find(id);
            user.State = "INA";
            context.SaveChanges();
            responseBody.Message = "Correcto";
            responseBody.Result = "Eliminado";
            return responseBody;
        }
    }
}