using System;
using System.Collections.Generic;
using Shared.DTO;
using Shared.MessageFormat;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces.BusinessLayerInterfaces
{
    public interface IHouseBusinessLayer
    {
        RequestMessageFormat<HouseDTO> Add(HouseDTO houseDTO);
        RequestMessageFormat<List<HouseDTO>> GetAll();
        RequestMessageFormat<HouseDTO> GetById(int id);
        RequestMessageFormat<HouseDTO> Delete(int id);
        RequestMessageFormat<HouseDTO> Update(HouseDTO houseDTO);
    }
}
