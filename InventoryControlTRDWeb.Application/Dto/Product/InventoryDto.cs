using System;

namespace InventoryControlTRDWeb.Application.Dto
{
    public class InventoryDto : BaseDto
    {
        public InventoryDto(Guid? productId, int amount, int min, int max)
        {
            ProductId = productId;
            Amount = amount;
            Min = min;
            Max = max;
        }

        public InventoryDto()
        {

        }
        public Guid? ProductId { get; set; }
        public ProductDto Product { get; set; }

        public int Amount { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
