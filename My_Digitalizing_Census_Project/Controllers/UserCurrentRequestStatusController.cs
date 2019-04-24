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
        public JsonResult<RequestMessageFormat<List<UserCurrentRequestStatusDTO>>> GetAll()
        {
            return Json(this.UserCurrentRequestStatusBusinessLogic.GetAll());
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult<RequestMessageFormat<UserCurrentRequestStatusDTO>> Get(int id)
        {

            return Json(this.UserCurrentRequestStatusBusinessLogic.GetById(id));
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult<RequestMessageFormat<UserCurrentRequestStatusDTO>> Add([FromBody]UserCurrentRequestStatusDTO userCurrentRequestStatusDTO)
        {
            return Json(this.UserCurrentRequestStatusBusinessLogic.Add(userCurrentRequestStatusDTO));
        }

        [System.Web.Mvc.HttpDelete]
        public JsonResult<RequestMessageFormat<UserCurrentRequestStatusDTO>> Delete(int id)
        {
            return Json(this.UserCurrentRequestStatusBusinessLogic.Delete(id));
        }

        //[System.Web.Mvc.HttpPatch]
        //public JsonResult<RequestMessageFormat<UserDTO>> UpdateHouse([FromBody]UserDTO userDTO)
        //{
        //    return Json(this.UserBusinessLogic.UpdateUser(userDTO));
        //}

    }
}
