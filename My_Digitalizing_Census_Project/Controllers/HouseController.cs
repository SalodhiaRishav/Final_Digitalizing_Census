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
        public JsonResult<RequestMessageFormat<List<HouseDTO>>> GetAll()
        {
            return Json(this.HouseBusinessLogic.GetAll());
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult<RequestMessageFormat<HouseDTO>> Get(int id)
        {

            return Json(this.HouseBusinessLogic.GetById(id));
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult<RequestMessageFormat<HouseDTO>> Add([FromBody]HouseDTO houseDTO)
        {
            return Json(this.HouseBusinessLogic.Add(houseDTO));
        }

        [System.Web.Mvc.HttpDelete]
        public JsonResult<RequestMessageFormat<HouseDTO>> Delete(int id)
        {
            return Json(this.HouseBusinessLogic.Delete(id));
        }

        //[System.Web.Mvc.HttpPatch]
        //public JsonResult<RequestMessageFormat<UserDTO>> UpdateHouse([FromBody]UserDTO userDTO)
        //{
        //    return Json(this.UserBusinessLogic.UpdateUser(userDTO));
        //}

    }
}
