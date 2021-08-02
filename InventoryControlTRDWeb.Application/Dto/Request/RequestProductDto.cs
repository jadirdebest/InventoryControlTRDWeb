using System;

namespace InventoryControlTRDWeb.Application.Dto
{
    public class RequestProductDto
    {
        public Guid? Id { get; set; }
        public Guid? ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int Amount { get; set; }
        public decimal SubTotalCostPrice { get; set; }
        public decimal SubTotalSalePrice { get; set; }
    }
}
