using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using DoggyStyleWS.Helpers;
using System.Web.Http.ModelBinding;

namespace DoggyStyleWS.ViewModel
{
    public class GenericObjectVM<T> where T:class
    {
        public GenericObjectVM()
        {
            this.Code = (int)HttpStatusCode.OK;
            this.Message = string.Empty;
        }

        public void SetServicesStatus(ServiceEnums status)
        {
            this.Code = int.Parse(status.Value());
            this.Message = status.Description();
        }

        public int Code { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public void SetErrors(ModelStateDictionary modelState)
        {
            var errors = modelState
                .Where(x => x.Value.Errors.Any())
                .Select(x => new
                {
                    element = x.Key,
                    errors = string.Join(",", x.Value.Errors.Select(y => y.ErrorMessage))
                });
            var errorsString = string.Join(",", errors);

            this.Code = (int)HttpStatusCode.BadRequest;
            this.Message = errorsString;
        }
    }
}