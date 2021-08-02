using System;

namespace InventoryControlTRDWeb.Application.Dto
{
    public class SubProductDto
    {
        public SubProductDto(Guid? productId, Guid? subProductId, int amount)
        {
            ProductId = productId;
            SubProductId = subProductId;
            Amount = amount;
        }

        public Guid? Id { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? SubProductId { get; set; }
        public int Amount { get; set; }
    }
}
