using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enums;

namespace DAL.Domain
{
    public class HouseMember
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public RelationToHeadType RelationToHead { get; set; }

        [Required]
        public GenderType Gender { get; set; }

        [Required]
        public OccupationStatusType OccupationStatus { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public MaritalStatusType MaritalStatus { get; set; }

        public int? AgeAtMarriage { get; set; }

        [Required]
        public OccupationNatureType OccupationNature { get; set; }

        [Required]
        public int VolunteerId { get; set; }

        [Required]
        public int HouseId { get; set; }

        [ForeignKey("VolunteerId")]
        public virtual User User { get; set; }

        [ForeignKey("HouseId")]
        public virtual House House { get; set; }



    }
}
