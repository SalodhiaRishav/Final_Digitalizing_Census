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
        public JsonResult<RequestMessageFormat<List<HouseMemberDTO>>> GetAll()
        {
            return Json(this.HouseMemberBusinessLogic.GetAll());
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult<RequestMessageFormat<HouseMemberDTO>> Get(int id)
        {

            return Json(this.HouseMemberBusinessLogic.GetById(id));
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult<RequestMessageFormat<HouseMemberDTO>> Add([FromBody]HouseMemberDTO houseMemberDTO)
        {
            return Json(this.HouseMemberBusinessLogic.Add(houseMemberDTO));
        }

        [System.Web.Mvc.HttpDelete]
        public JsonResult<RequestMessageFormat<HouseMemberDTO>> Delete(int id)
        {
            return Json(this.HouseMemberBusinessLogic.Delete(id));
        }

        //[System.Web.Mvc.HttpPatch]
        //public JsonResult<RequestMessageFormat<UserDTO>> UpdateHouse([FromBody]UserDTO userDTO)
        //{
        //    return Json(this.UserBusinessLogic.UpdateUser(userDTO));
        //}
    }
}
