using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.RepositoryInterface;
using Shared.Interfaces.BusinessLayerInterfaces;

namespace BL.BusinessLogics
{
    public class UserBusinessLogic : IUserBusinessLayer
    {
        private IUserRepository UserRepository;
        public UserBusinessLogic(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

    }
}
