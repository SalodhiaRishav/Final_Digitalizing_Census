using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enums;

namespace DAL.Domain
{
    public class User : DomainBaseClass
    {
        [Index(IsUnique = true)]
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

        [Index(IsUnique = true)]
        [StringLength(12)]
        [Required]
        public string AadharNumber { get; set; }

        [Required]
        public BooleanType IsApprover { get;set }
    }
}
