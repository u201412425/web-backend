using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DoggyStyleWS.Models;
using DoggyStyleWS.ViewModel.UserViewModel;
using DoggyStyleWS.ViewModel;
using System.Web;

namespace DoggyStyleWS.Controllers
{
    public class SessionController : BaseController
    {
        
        public GenericObjectVM<UserJson> Get()
        {
            var responseBody = new GenericObjectVM<UserJson>();
            try
            {
                var user = Request.Headers.GetValues("User").First().ToString();
                var password = Request.Headers.GetValues("Password").First().ToString();
                if(user != null && password != null)
                {
                    var usuario = context.User.Where(x => x.UserName.Equals(user) && x.Password.Equals(password)).Select(x => new UserJson {
                        UserId = x.UserId,
                        UserName = x.UserName,
                        Type = x.Type
                    }).FirstOrDefault();
                    if(usuario != null)
                    {
                        SessionUser sessionUser = context.SessionUser.Where(x => x.UserId.Equals(usuario.UserId)).FirstOrDefault();
                        if(sessionUser == null)
                        {
                            sessionUser = new SessionUser();
                            sessionUser.UserId = usuario.UserId;
                            sessionUser.Token = Guid.NewGuid();
                            context.SessionUser.Add(sessionUser);
                            context.SaveChanges();
                        }
                        usuario.token = sessionUser.Token.ToString();
                        HttpContext.Current.Response.AddHeader("Token", sessionUser.Token.ToString());
                        responseBody.Result = usuario;
                        responseBody.Code = (int)HttpStatusCode.OK;
                        responseBody.Message = "Logueado";
                    }
                    else
                    {
                        responseBody.Code = (int)HttpStatusCode.InternalServerError;
                        responseBody.Message = "Error del Servidor";
                    }

                   
                }
                else
                {
                    responseBody.Code = (int)HttpStatusCode.NoContent;
                    responseBody.Message = "Datos nulos";
                }

                return responseBody;
            }
            catch (Exception)
            {

                responseBody.Code = (int)HttpStatusCode.InternalServerError;
                responseBody.Message = "Error del Servidor";
                return responseBody;
            }
        }
    }
}