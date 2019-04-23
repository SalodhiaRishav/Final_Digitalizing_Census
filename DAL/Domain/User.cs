using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enums;

namespace DAL.Domain
{
    public class User : DomainBaseClass
    {
        [MaxLength(50)]
        [Index(IsUnique =true)]
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ProfileImage { get; set; }

        [MaxLength(12)]
        [Index(IsUnique = true)]
        [Required]
        public string AadharNumber { get; set; }

        [Required]
        public BooleanType IsApprover { get; set; }

        
        public virtual ICollection<HouseMember> RegisteredHouseMembers { get; set; }
    }
}
