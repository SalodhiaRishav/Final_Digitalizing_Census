using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Interfaces.BusinessLayerInterfaces;
using DAL.RepositoryInterface;
namespace BL.BusinessLogics
{
    public class UserCurrentRequestStatusBusinessLogic : IUserCurrentRequestStatusBusinessLayer
    {
        private IUserCurrentRequestStatusRepository UserCurrentRequestStatusRepository;
        public UserCurrentRequestStatusBusinessLogic(IUserCurrentRequestStatusRepository userCurrentRequestStatusRepository)
        {
            UserCurrentRequestStatusRepository = userCurrentRequestStatusRepository;
        }
    }
}
