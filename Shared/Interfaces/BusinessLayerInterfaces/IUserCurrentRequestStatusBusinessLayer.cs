using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;
using Shared.MessageFormat;

namespace Shared.Interfaces.BusinessLayerInterfaces
{
    public interface IUserCurrentRequestStatusBusinessLayer
    {
        RequestMessageFormat<UserCurrentRequestStatusDTO> Add(UserCurrentRequestStatusDTO userDTO);
        RequestMessageFormat<List<UserCurrentRequestStatusDTO>> GetAll();
        RequestMessageFormat<UserCurrentRequestStatusDTO> GetById(int id);
        RequestMessageFormat<UserCurrentRequestStatusDTO> Delete(int id);
        RequestMessageFormat<UserCurrentRequestStatusDTO> Update(UserCurrentRequestStatusDTO userDTO);
    }
}
