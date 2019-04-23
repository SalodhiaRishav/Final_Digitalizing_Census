using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace My_Digitalizing_Census_Project.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
              new { id = RouteParameter.Optional });
        }
        //var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
        //formatter.SerializerSettings.ContractResolver =
        //    new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
        //}

}
}