using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;

namespace Shared.DTO
{
    public class HouseDTO
    {
        public int ID { get; set; }
    
        public string BuildingNumber { get; set; }
      
        public string StreetName { get; set; }
      
        public string City { get; set; }
     
        public string State { get; set; }
      
        public string HeadName { get; set; }
        
        public OwnershipStatusType OwnershipStatus { get; set; }
      
        public int NumberOfRooms { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}

