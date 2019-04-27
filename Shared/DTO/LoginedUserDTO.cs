using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;

namespace Shared.DTO
{
    public class LoginedUserDTO
    {
       
            public int ID { get; set; }

            public string Email { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Password { get; set; }

            public string ProfileImage { get; set; }

            public string AadharNumber { get; set; }

            public BooleanType IsApprover { get; set; }

            public DateTime ModifiedOn { get; set; }

            public DateTime CreatedOn { get; set; }

            public UserRequestStatusType UserRequestStatus { get; set; }

        
    }
}
