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

        RequestMessageFormat AddNewUser(UserDTO userDTO);
        List<UserDTO> GetAllUsers();
        UserDTO GetUserById(int id);
        RequestMessageFormat DeleteUser(int id);
        RequestMessageFormat UpdateUser(UserDTO userDTO);

    }
}
