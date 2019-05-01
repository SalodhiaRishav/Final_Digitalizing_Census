using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class UserImageDTO
    {
        public UserDTO User { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
    }
}
