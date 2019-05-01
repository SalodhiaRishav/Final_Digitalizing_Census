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
using System.IO;
using System.Drawing;
using System.Web;
using Shared.MessageFormat;



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
            RequestMessageFormat<List<UserDTO>> tempResponse = this.UserBusinessLogic.GetAll();
            List<UserDTO> userList = tempResponse.Data;
            
           

            if (userList!=null)
            {
                int length = userList.Count;   
                for(int i=0;i<length;++i)
                {

                    userList[i].ProfileImage= getImage(userList[i].ProfileImage);
                }
            }
            RequestMessageFormat<List<UserDTO>> response = new RequestMessageFormat<List<UserDTO>>();
            response.Data = userList;
            response.Message = tempResponse.Message;
            response.Success = tempResponse.Success;
           // this.UserBusinessLogic.GetAll().Data = userList;

            


            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [System.Web.Mvc.HttpGet]
        public HttpResponseMessage Get(int id)
        {
            RequestMessageFormat<UserDTO> tempResponse = this.UserBusinessLogic.GetById(id);
            UserDTO user = tempResponse.Data;
            if(user!=null)
            {
                user.ProfileImage = getImage(user.ProfileImage);

            }
            RequestMessageFormat<UserDTO> response = new RequestMessageFormat<UserDTO>();
            response.Data = user;
            response.Message = tempResponse.Message;
            response.Success = tempResponse.Success;
            return Request.CreateResponse(HttpStatusCode.OK,response);        
        }

        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage Add([FromBody]UserImageDTO userImageDTO)
        {

            UserDTO userDTO = userImageDTO.User;
            userDTO.ProfileImage = saveImage(userImageDTO.Image, userImageDTO.Name);
            return Request.CreateResponse(HttpStatusCode.OK, this.UserBusinessLogic.Add(userDTO));
        }

        [System.Web.Mvc.HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.UserBusinessLogic.Delete(id));
        }

        public HttpResponseMessage Put([FromBody]UserDTO userDTO)
        {
            return Request.CreateResponse(HttpStatusCode.OK, this.UserBusinessLogic.Update(userDTO));

        
        }
        
        public string saveImage(string image, string name)
        {
            string imageName = null;
            imageName = new string(Path.GetFileNameWithoutExtension(name).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(name);

            byte[] bytes = Convert.FromBase64String(image);
            using (Image actualImage = Image.FromStream(new MemoryStream(bytes)))
            {
                //actualImage.Save("output.jpg", ImageFormat.Jpeg); 
                actualImage.Save(System.Web.HttpContext.Current.Server.MapPath("~/Images/" + imageName));// Or Png
            }

            return imageName;
        }


        public string getImage(string imageName)
        {

            string path = HttpContext.Current.Server.MapPath("~/Images/") + imageName;
            string base64String;
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }

        }



    }
}
