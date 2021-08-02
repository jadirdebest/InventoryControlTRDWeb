using System;

namespace InventoryControlTRD.Domain.Models
{
    public class SubProduct
    {
        public Guid? Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid SubProductId { get; set; }
        public int Amount { get; set; }
    }
}
