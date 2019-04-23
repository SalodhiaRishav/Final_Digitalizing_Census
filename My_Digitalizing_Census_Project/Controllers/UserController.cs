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
        public JsonResult<List<UserDTO>> GetAllUsers()
        {

            return Json(this.UserBusinessLogic.GetAllUsers());
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult<UserDTO> GetUser(int id)
        {

            return Json(this.UserBusinessLogic.GetUserById(id));
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult<RequestMessageFormat> AddUser([FromBody]UserDTO userDTO)
        {
            return Json(this.UserBusinessLogic.AddNewUser(userDTO));
        }

        [System.Web.Mvc.HttpDelete]
        public JsonResult<RequestMessageFormat> DeleteUser(int id)
        {
            return Json(this.UserBusinessLogic.DeleteUser(id));
        }

        //[System.Web.Mvc.HttpPut]
        //public JsonResult<RequestMessageFormat> UpdateUser([FromBody]UserDTO userDTO)
        //{
        //    return Json(this.UserBusinessLogic.UpdateUser(userDTO));
        //}

    }
}
