using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using Shared.Interfaces;
using DAL.RepositoryInterface;

namespace DAL.Repositories
{
    public class UserCurrentRequestStatusRepository : RepositoryBaseClass<UserCurrentRequestStatus>,IUserCurrentRequestStatusRepository
    {
        public UserCurrentRequestStatusRepository(IUserCurrentRequestStatusUnitOfWork userCurrentRequestStatusUnitOfWork) : base(userCurrentRequestStatusUnitOfWork)
        {

        }

       
    }
}
