using System;

namespace InventoryControlTRD.Domain.Models
{
    public abstract class Base
    {
        public Guid? Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool Actived { get; set; }
    }
}
