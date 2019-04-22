using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace DAL.Domain
{
    public class House : DomainBaseClass
    {
        [Required]
        public string BuildingNumber { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string HeadName { get; set; }

        [Required]
        public OwnershipStatusType OwnershipStatus { get; set; }

        [Required]
        public int NumberOfRooms { get; set; }

        public virtual ICollection<HouseMember> HouseMembers { get; set; }


    }
}
