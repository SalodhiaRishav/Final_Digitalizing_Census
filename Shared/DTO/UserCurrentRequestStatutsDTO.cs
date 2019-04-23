using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;

namespace Shared.DTO
{
    public class UserCurrentRequestStatutsDTO
    {
        public int ID { get; set; }

        public int UserId { get; set; }

        public UserRequestStatusType UserRequestType { get; set; }
    
        public DateTime ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
