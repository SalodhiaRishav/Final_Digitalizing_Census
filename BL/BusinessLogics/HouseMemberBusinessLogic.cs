using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.RepositoryInterface;
using Shared.Interfaces.BusinessLayerInterfaces;

namespace BL.BusinessLogics
{
   public class HouseMemberBusinessLogic : IHouseMemberBusinessLayer 
    {
        private IHouseMemberRepository HouseMemberRepository;
        public HouseMemberBusinessLogic(IHouseMemberRepository houseMemberRepository)
        {
            HouseMemberRepository = houseMemberRepository;
        }
    }
}
