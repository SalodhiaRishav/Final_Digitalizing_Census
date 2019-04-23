using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.RepositoryInterface;
using Shared.Interfaces.BusinessLayerInterfaces;
using DAL.Domain;
using Shared.DTO;
using Shared.MessageFormat;

namespace BL.BusinessLogics
{
    public class UserBusinessLogic : IUserBusinessLayer
    {
        private AutoMapperConfigurations AutoMapperConfigurations = new AutoMapperConfigurations();
        private IUserRepository UserRepository;
        RequestMessageFormat requestMessageFormat = new RequestMessageFormat();
        public UserBusinessLogic(IUserRepository userRepository)
        {
            
            UserRepository = userRepository;
        }

        public List<UserDTO> GetAllUsers()
        {
            List<User> users = this.UserRepository.List;
            return this.AutoMapperConfigurations.UserListToUserDTOList(users);
        }

        public UserDTO GetUserById(int id)
        {
            User user = this.UserRepository.FindById(id);
            return this.AutoMapperConfigurations.UserToUserDTO(user);
        }

        public RequestMessageFormat AddNewUser(UserDTO userDTO)
        {
            User user = this.AutoMapperConfigurations.UserDTOToUser(userDTO);
            user.CreatedOn = DateTime.Now;
            user.ModifiedOn = DateTime.Now;
            bool isAdded= this.UserRepository.Add(user);
            

            if(isAdded)
            {
                requestMessageFormat.Message = "Added Successfully";
            }
            else
            {
                requestMessageFormat.Message = "Some Error Occurred";
            }

            return requestMessageFormat;

        }
        public RequestMessageFormat DeleteUser(int id)
        {
            User user = this.UserRepository.FindById(id);
            if(user==null)
            {
                requestMessageFormat.Message = "User Not Exist";
            }
            else
            {
                bool isDeleted=this.UserRepository.Delete(user);
                if(isDeleted)
                {
                    requestMessageFormat.Message = "Deleted Successfully";
                }
                else
                {
                    requestMessageFormat.Message = "Some Error Occurred";
                }
            }

            return requestMessageFormat;
        }

        public RequestMessageFormat UpdateUser(UserDTO userDTO)
        {

            User user = this.AutoMapperConfigurations.UserDTOToUser(userDTO);
           
                bool isUpdated = this.UserRepository.Update(user);
                if (isUpdated)
                {
                    requestMessageFormat.Message = "Updated Successfully";
                }
                else
                {
                    requestMessageFormat.Message = "Some Error Occurred";
                }
            

            return requestMessageFormat;
        }

    }
}
