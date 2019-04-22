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
    public class HouseMemberRepository : RepositoryBaseClass<HouseMember>,IHouseMemberRepository
    {
        public HouseMemberRepository(IHouseMemberUnitOfWork houseMemberUnitOfWork) : base(houseMemberUnitOfWork)
        {

        }
    }
}
