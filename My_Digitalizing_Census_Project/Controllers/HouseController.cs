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
    public class HouseController : ApiController
    {
        private IHouseBusinessLayer HouseBusinessLogic;

        public HouseController(IHouseBusinessLayer houseBusinessLayer)
        {
            HouseBusinessLogic = houseBusinessLayer;
        }

        

        [System.Web.Mvc.HttpGet]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.HouseBusinessLogic.GetAll());
        }

        [Route("/api/house/")]
        [System.Web.Mvc.HttpGet]
        public HttpResponseMessage GetStateReport(string state)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.HouseBusinessLogic.StatePopulation());
        }

        [System.Web.Mvc.HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.HouseBusinessLogic.GetById(id));

        }

        
      

        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage Add([FromBody]HouseDTO houseDTO)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.HouseBusinessLogic.Add(houseDTO));


        }

        [System.Web.Mvc.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.HouseBusinessLogic.Delete(id));
        }

        [System.Web.Mvc.HttpPut]
        public HttpResponseMessage Put([FromBody]HouseDTO houseDTO)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.HouseBusinessLogic.Update(houseDTO));

           
        }

    }
}
