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
            RequestMessageFormat requestMessageFormat = new RequestMessageFormat();

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

    }
}
