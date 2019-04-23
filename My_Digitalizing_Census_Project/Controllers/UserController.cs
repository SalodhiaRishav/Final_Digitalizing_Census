using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
//using System.Web.Mvc;

namespace My_Digitalizing_Census_Project.Controllers
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Company { get; set; }


    }
    public class UserController : ApiController
    {
        //List<string> 
        [System.Web.Mvc.HttpGet]
        public JsonResult<List<UserModel>> Get()
        {

            var users = new List<UserModel>();
            UserModel user;
            for (int i = 1; i < 100; i++)
            {
                user = new UserModel
                {
                    UserId = i,
                    UserName = "User-" + i,
                    Company = "Company-" + i
                };
                users.Add(user);
            }
            //UserModel user = new UserModel
            //{
            //    UserId = 12,
            //    UserName = "User",
            //    Company = "Company"
            //};

            return Json(users);
        }

        public string Get(int id)
        {
            return "value";
        }
    }
}
