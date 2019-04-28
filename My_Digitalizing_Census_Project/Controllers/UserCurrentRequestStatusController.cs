using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Shared.DTO;
using Shared.Interfaces.BusinessLayerInterfaces;
using Shared.MessageFormat;

namespace My_Digitalizing_Census_Project.Controllers
{
    public class UserCurrentRequestStatusController : ApiController
    {

        private IUserCurrentRequestStatusBusinessLayer UserCurrentRequestStatusBusinessLogic;

        public UserCurrentRequestStatusController(IUserCurrentRequestStatusBusinessLayer userCurrentRequestStatusBusinessLayer)
        {
            UserCurrentRequestStatusBusinessLogic = userCurrentRequestStatusBusinessLayer;
        }


        [System.Web.Mvc.HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.UserCurrentRequestStatusBusinessLogic.GetAll());
        }

        [System.Web.Mvc.HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.UserCurrentRequestStatusBusinessLogic.GetById(id));
        }

        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage Add([FromBody]UserCurrentRequestStatusDTO userCurrentRequestStatusDTO)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.UserCurrentRequestStatusBusinessLogic.Add(userCurrentRequestStatusDTO));
        }

        [System.Web.Mvc.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.UserCurrentRequestStatusBusinessLogic.Delete(id));
        }


        [System.Web.Mvc.HttpPut]
        public HttpResponseMessage Put([FromBody]UserCurrentRequestStatusDTO userCurrentRequestStatusDTO)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.UserCurrentRequestStatusBusinessLogic.Update(userCurrentRequestStatusDTO));
          
        }

    }
}
