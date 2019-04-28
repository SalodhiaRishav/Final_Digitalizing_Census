using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Shared.DTO;
using System.Web.Http;
using System.Web.Http.Results;
using DAL.Repositories;
using DAL.UnitOfWork;
using System.Web.Mvc;
using Shared.MessageFormat;
using BL.BusinessLogics;
using Shared.Interfaces.BusinessLayerInterfaces;
using System.Web.Http.Cors;


//using System.Web.Mvc;

namespace My_Digitalizing_Census_Project.Controllers
{
    //[EnableCors(origins: "http://localhost:1305/api/user", headers: "*", methods: "*")]
    public class UserController : ApiController
    {

        private IUserBusinessLayer UserBusinessLogic;
       
        public UserController(IUserBusinessLayer userBusinessLayer)
        {
            UserBusinessLogic = userBusinessLayer;
        }


        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK,this.UserBusinessLogic.GetAll());
        }

        [System.Web.Mvc.HttpGet]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.UserBusinessLogic.GetById(id));        
        }

        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage Add([FromBody]UserDTO userDTO)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.UserBusinessLogic.Add(userDTO));
        }

        [System.Web.Mvc.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.UserBusinessLogic.Delete(id));
        }

        public HttpResponseMessage UpdateUser([FromBody]UserDTO userDTO)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.UserBusinessLogic.Update(userDTO));

        
        }

    }
}
