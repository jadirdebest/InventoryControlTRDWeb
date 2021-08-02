using System;

namespace InventoryControlTRD.Domain.Models
{
    public class Inventory : Base
    {
        public Guid? ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
