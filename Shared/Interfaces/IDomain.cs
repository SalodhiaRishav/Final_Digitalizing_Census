using System;
using System.ComponentModel.DataAnnotations;


namespace Shared.Interfaces
{
    public interface IDomain
    {
        
        int ID { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime ModifiedOn { get; set; }

    }
}
