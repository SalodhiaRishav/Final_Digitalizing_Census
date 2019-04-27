using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using My_Digitalizing_Census_Project.Models;
using Shared.DTO;
using Shared.Interfaces.BusinessLayerInterfaces;

namespace My_Digitalizing_Census_Project.Controllers
{
    public class LoginController : ApiController
    {
        private IUserBusinessLayer UserBusinessLogic;

        public LoginController(IUserBusinessLayer userBusinessLayer)
        {
            UserBusinessLogic = userBusinessLayer;
        }
        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage Login([FromBody]LoginUserDTO loginUserDTO)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.UserBusinessLogic.LoginUser(loginUserDTO));
         }
    }
}
