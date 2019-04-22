using System;
using System.ComponentModel.DataAnnotations;
using Shared.Interfaces;

namespace DAL.Domain
{
        public class DomainBaseClass : IDomain
        {
            [Required]
            public int ID { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime CreatedOn { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime ModifiedOn { get; set; }
        }

}
