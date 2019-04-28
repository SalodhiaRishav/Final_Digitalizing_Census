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
    public class HouseMemberController : ApiController
    {
        private IHouseMemberBusinessLayer HouseMemberBusinessLogic;

        public HouseMemberController(IHouseMemberBusinessLayer houseMemberBusinessLayer)
        {
            HouseMemberBusinessLogic = houseMemberBusinessLayer;
        }


        
        [System.Web.Mvc.HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.HouseMemberBusinessLogic.GetAll());

       
        }

        [System.Web.Mvc.HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.HouseMemberBusinessLogic.GetById(id));

        }

        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage Add([FromBody]HouseMemberDTO houseMemberDTO)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.HouseMemberBusinessLogic.Add(houseMemberDTO));

        
        }

        [System.Web.Mvc.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.HouseMemberBusinessLogic.Delete(id));

           
        }

        [System.Web.Mvc.HttpPatch]
        public HttpResponseMessage UpdateHouse([FromBody]HouseMemberDTO houseMemberDTO)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.HouseMemberBusinessLogic.Update(houseMemberDTO));

        }
    }
}
