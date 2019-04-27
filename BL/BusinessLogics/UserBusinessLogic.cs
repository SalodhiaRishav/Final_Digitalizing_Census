using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.RepositoryInterface;
using Shared.Interfaces.BusinessLayerInterfaces;
using DAL.Domain;
using Shared.DTO;
using Shared.Enums;
using Shared.MessageFormat;

namespace BL.BusinessLogics
{
    public class UserBusinessLogic : IUserBusinessLayer
    {
        private AutoMapperConfigurations AutoMapperConfigurations = new AutoMapperConfigurations();
        private IUserRepository UserRepository;
        private IUserCurrentRequestStatusRepository UserCurrentRequestStatusRepository;
       //todo
       // private List<User> UserCacheList=null;
     
        public UserBusinessLogic(IUserRepository userRepository,IUserCurrentRequestStatusRepository userCurrentRequestStatusRepository)
        {      
            UserRepository = userRepository;
            UserCurrentRequestStatusRepository = userCurrentRequestStatusRepository;
        }

        //todo
        //private void RefreshUserList()
        //{
        //    if (this.UserCacheList == null)
        //    {
        //        this.UserCacheList = this.UserRepository.List;
        //    }
      
        //}

        public RequestMessageFormat<List<UserDTO>> GetAll()
        {
            List<User> users = this.UserRepository.List;
            List<UserDTO> userDTOList =this.AutoMapperConfigurations.UserListToUserDTOList(users);
            RequestMessageFormat<List<UserDTO>> response = new RequestMessageFormat<List<UserDTO>>();
            if(users.Count==0)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "Empty List";
            }
            else
            {
                response.Data = userDTOList;
                response.Success = true;
                response.Message = "Data fetched successfully";
            }
            return response;
        }

        public RequestMessageFormat<UserDTO> GetById(int id)
        {
            User user = this.UserRepository.FindById(id);
            UserDTO userDTO=this.AutoMapperConfigurations.UserToUserDTO(user);
            RequestMessageFormat<UserDTO> response = new RequestMessageFormat<UserDTO>();
            if (user==null)
            {
                response.Data = null;
                response.Success = false;
                response.Message = "User Not Found";
            }
            else
            {
                response.Data = userDTO;
                response.Success = true;
                response.Message = "Data fetched successfully";
            }
            return response;
        }

        //private bool CheckNullData(UserDTO userDTO)
        //{
        //    if (userDTO.LastName == null || userDTO.FirstName == null || userDTO.Email == null ||
        //     userDTO.AadharNumber == null || userDTO.ProfileImage == null || userDTO.Password == null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //private bool CheckEmptyData(UserDTO userDTO)
        //{
        //    if (userDTO.LastName.Trim(' ') == "" || userDTO.FirstName.Trim(' ') == "" || userDTO.Email.Trim(' ') == "" ||
        //       userDTO.AadharNumber.Trim(' ') == "" || userDTO.ProfileImage.Trim(' ') == "" || userDTO.Password.Trim(' ') == "")
        //    {
                
        //        return true;
        //    }
        //    return false;
        //}

        private bool CheckEmptyData(UserDTO userDTO)
        {
            if (string.IsNullOrWhiteSpace(userDTO.FirstName) || string.IsNullOrWhiteSpace(userDTO.LastName) || string.IsNullOrWhiteSpace(userDTO.Email) ||
              string.IsNullOrWhiteSpace(userDTO.Password) || string.IsNullOrWhiteSpace(userDTO.ProfileImage))
            {
                return true;
            }
            return false;
        }

        private bool CheckDuplicateEmail(UserDTO userDTO)
        {
           int count= UserRepository.Find(user => user.Email == userDTO.Email).ToList().Count();
            if(count!=0)
            {
                return true;
            }
            return false;
        }

        private bool CheckDuplicateAadhar(UserDTO userDTO)
        {
            int count = UserRepository.Find(user => user.AadharNumber == userDTO.AadharNumber).ToList().Count();
            if (count != 0)
            {
                return true;
            }
            return false;
        }

        public RequestMessageFormat<UserDTO> Add(UserDTO userDTO)
        {
           
            userDTO.CreatedOn = DateTime.Now;
            userDTO.ModifiedOn = DateTime.Now;
            userDTO.IsApprover = BooleanType.False;
            RequestMessageFormat<UserDTO> response = new RequestMessageFormat<UserDTO>();

            if (this.CheckEmptyData(userDTO))
            {
                response.Message = "Entered Invalid Data";
                response.Data = null;
                response.Success = false;
                return response;
            }
            if (this.CheckDuplicateAadhar(userDTO))
            {
                response.Message = "Aadhar Number Already Exists";
                response.Data = null;
                response.Success = false;
                return response;
            }

            if (this.CheckDuplicateEmail(userDTO))
            {
                response.Message = "Email Already Exists";
                response.Data = null;
                response.Success = false;
                return response;
            }




            User user = this.AutoMapperConfigurations.UserDTOToUser(userDTO);
            bool isAdded = this.UserRepository.Add(user);

            if (isAdded)
            {
                response.Message = "Added Successfully";
                userDTO.ID = user.ID;
                UserCurrentRequestStatus userCurrentRequestStatus = new UserCurrentRequestStatus();
                userCurrentRequestStatus.UserId = user.ID;
                userCurrentRequestStatus.UserRequestType = UserRequestStatusType.Pending;
                userCurrentRequestStatus.CreatedOn = DateTime.Now;
                userCurrentRequestStatus.ModifiedOn = DateTime.Now;
                
                this.UserCurrentRequestStatusRepository.Add(userCurrentRequestStatus);
                
                response.Data = userDTO;
                response.Success = true;
                return response;
            }
            else
            {
                response.Message = "Some Error Occurred while adding data please try again";
                response.Data = null;
                response.Success = true;
                return response;
            }

          

        }

        public RequestMessageFormat<LoginedUserDTO> LoginUser(LoginUserDTO loginUserDTO)
        {
            RequestMessageFormat<LoginedUserDTO> response = new RequestMessageFormat<LoginedUserDTO>();

            int count = this.UserRepository.Find(user => user.Email == loginUserDTO.Email).ToList().Count();

            if (count == 0)
            {
                response.Data = null;
                response.Message = "No User found with this email";
                response.Success = false;
                return response;
            }
            else
            {
                count = 0;
                count= this.UserRepository.Find(user => user.Email == loginUserDTO.Email && user.Password == loginUserDTO.Password).ToList().Count();
                if(count!=0)
                {
                    User user = this.UserRepository.Find(theuser => theuser.Email == loginUserDTO.Email).ToList().First();
                    UserCurrentRequestStatus userCurrentRequestStatus = this.UserCurrentRequestStatusRepository.Find(status => status.UserId == user.ID).ToList().First();
                    LoginedUserDTO loginedUserDTO= this.AutoMapperConfigurations.UserToLoginedUserDTO(user);
                    loginedUserDTO.UserRequestStatus = userCurrentRequestStatus.UserRequestType;

                    response.Data = loginedUserDTO;

                    response.Message = "You are successfully loggedIn";
                    response.Success = true;
                    return response;
                }
              else
                {
                    response.Data = null;
                    response.Message = "Incorrect Password";
                    response.Success = false;
                    return response;
                }

            }
        }
        public RequestMessageFormat<UserDTO> Delete(int id)
        {
            RequestMessageFormat<UserDTO> response = new RequestMessageFormat<UserDTO>();
            User user = this.UserRepository.FindById(id);


            if(user==null)
            {
                response.Message = "User Not Exist";
                response.Success = false;
                response.Data = null;
            }
            else
            {
                bool isDeleted=this.UserRepository.Delete(user);
                if(isDeleted)
                {
                    response.Message = "Deleted Successfully";
                    response.Success = true;
                    response.Data = null;
                }
                else
                {
                    response.Message = "Some Error Occurred while deleting data. Please try again";
                    response.Success = false;
                    response.Data = null;
                }
            }

            return response;
        }

        public RequestMessageFormat<UserDTO> Update(UserDTO userDTO)
        {
            RequestMessageFormat<UserDTO> response = new RequestMessageFormat<UserDTO>();

            userDTO.ModifiedOn = DateTime.Now;
            User user = this.AutoMapperConfigurations.UserDTOToUser(userDTO);
           
                bool isUpdated = this.UserRepository.Update(user);
                if (isUpdated)
                {
                    response.Message = "Updated Successfully";
                }
                else
                {
                    response.Message = "Some Error Occurred";
                }
            

            return response;
        }

    }
}
