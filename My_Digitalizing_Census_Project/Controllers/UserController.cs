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
//using System.Web.Mvc;

namespace My_Digitalizing_Census_Project.Controllers
{
    public class UserController : ApiController
    {

        private IUserBusinessLayer UserBusinessLogic;
       
        public UserController(IUserBusinessLayer userBusinessLayer)
        {
            UserBusinessLogic = userBusinessLayer;
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult<RequestMessageFormat<List<UserDTO>>> GetAll()
        {
            return Json(this.UserBusinessLogic.GetAll());
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult<RequestMessageFormat<UserDTO>> Get(int id)
        {

            return Json(this.UserBusinessLogic.GetById(id));
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult<RequestMessageFormat<UserDTO>> Add([FromBody]UserDTO userDTO)
        {
            return Json(this.UserBusinessLogic.Add(userDTO));
        }

        [System.Web.Mvc.HttpDelete]
        public JsonResult<RequestMessageFormat<UserDTO>> Delete(int id)
        {
            return Json(this.UserBusinessLogic.Delete(id));
        }

        //[System.Web.Mvc.HttpPatch]
        //public JsonResult<RequestMessageFormat<UserDTO>> UpdateUser([FromBody]UserDTO userDTO)
        //{
        //    return Json(this.UserBusinessLogic.UpdateUser(userDTO));
        //}

    }
}
