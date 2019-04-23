using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Interfaces.BusinessLayerInterfaces;
using DAL.Domain;
using Shared.DTO;
using DAL.RepositoryInterface;

namespace BL.BusinessLogics
{
   public class HouseBusinessLogic : IHouseBusinessLayer
    {
        AutoMapperConfigurations autoMapperConfigurations;
        private IHouseRepository HouseRepository;
        public HouseBusinessLogic(IHouseRepository houseRepository)
        {
            HouseRepository = houseRepository;
            autoMapperConfigurations = new AutoMapperConfigurations();
        }

        public List<HouseDTO> GetAllHouse()
        {
            List<House> houses = this.HouseRepository.List;
            return this.autoMapperConfigurations.HouseListToHouseDTOList(houses);
        }

        public HouseDTO GetById(int id)
        {
            House house = this.HouseRepository.FindById(id);
            return this.autoMapperConfigurations.HouseToHouseDTO(house);
        }

        public void AddHouse(HouseDTO houseDTO)
        {
            
        }
    }
}
