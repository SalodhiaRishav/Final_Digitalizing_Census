using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Interfaces.BusinessLayerInterfaces;

using DAL.RepositoryInterface;

namespace BL.BusinessLogics
{
   public class HouseBusinessLogic : IHouseBusinessLayer
    {
        private IHouseRepository HouseRepository;
        public HouseBusinessLogic(IHouseRepository houseRepository)
        {
            HouseRepository = houseRepository;
        }
    }
}
