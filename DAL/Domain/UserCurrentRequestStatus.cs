using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Enums;

namespace DAL.Domain
{
   public class UserCurrentRequestStatus : DomainBaseClass
    {

        public int UserId { get; set; }

        [Required]
        public UserRequestStatusType UserRequestType { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}
