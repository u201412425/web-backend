using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
namespace DoggyStyleWS.Helpers
{
    public enum ServiceEnums
    {
        [Description("Sent parameters were invalid")]
        [AmbientValue("240")]
        InvalidParameters,

        [Description("Provider already postulate to the advert")]
        [AmbientValue("241")]
        ProviderAlreadyPostulate,

        [Description("Not more providers allowed")]
        [AmbientValue("242")]
        NoMoreProvidersAllowed,

        [Description("Postulation doesnt exists")]
        [AmbientValue("243")]
        PostulationNotExists,
    }
}