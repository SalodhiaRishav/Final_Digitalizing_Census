using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;
using Shared.MessageFormat;

namespace Shared.Interfaces.BusinessLayerInterfaces
{
    public interface IUserBusinessLayer
    {

        RequestMessageFormat<UserDTO> Add(UserDTO userDTO);
        RequestMessageFormat<List<UserDTO>> GetAll();
        RequestMessageFormat<UserDTO> GetById(int id);
        RequestMessageFormat<UserDTO> Delete(int id);
        RequestMessageFormat<UserDTO> Update(UserDTO userDTO);
        RequestMessageFormat<LoginedUserDTO> LoginUser(LoginUserDTO loginUserDTO);

    }
}
