using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using DAL.RepositoryInterface;
using Shared.Interfaces;


namespace DAL.Repositories
{
    public class UserRepository : RepositoryBaseClass<User>,IUserRepository
    {
        public UserRepository(IUserUnitOfWork userUnitOfWork) : base(userUnitOfWork)
        {

        }
    }
}
