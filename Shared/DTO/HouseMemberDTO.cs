using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;

namespace Shared.DTO
{
   public class HouseMemberDTO
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public RelationToHeadType RelationToHead { get; set; }

        public GenderType Gender { get; set; }

        public OccupationStatusType OccupationStatus { get; set; }

        public DateTime DateOfBirth { get; set; }

        public MaritalStatusType MaritalStatus { get; set; }

        public int? AgeAtMarriage { get; set; }

        public OccupationNatureType OccupationNature { get; set; }

        public int VolunteerId { get; set; }

        public int HouseId { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
