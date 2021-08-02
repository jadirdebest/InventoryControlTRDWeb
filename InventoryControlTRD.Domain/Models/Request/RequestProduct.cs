using System;

namespace InventoryControlTRD.Domain.Models
{
    public class RequestProduct
    {
        public Guid? Id { get; set; }
        public Guid? ProductId { get; set; }
        public int Amount { get; set; }
        public decimal SubTotalCostPrice { get; set; }
        public decimal SubTotalSalePrice { get; set; }
    }
}
