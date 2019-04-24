using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;
using Shared.MessageFormat;

namespace Shared.Interfaces.BusinessLayerInterfaces
{
    public interface IHouseMemberBusinessLayer
    {
        RequestMessageFormat<HouseMemberDTO> Add(HouseMemberDTO houseMemberDTO);
        RequestMessageFormat<List<HouseMemberDTO>> GetAll();
        RequestMessageFormat<HouseMemberDTO> GetById(int id);
        RequestMessageFormat<HouseMemberDTO> Delete(int id);
        RequestMessageFormat<HouseMemberDTO> Update(HouseMemberDTO houseMemberDTO);
    }
}
