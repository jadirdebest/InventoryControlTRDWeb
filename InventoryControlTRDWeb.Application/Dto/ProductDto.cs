using InventoryControlTRDWeb.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Dto
{
    public class ProductDto : BaseDto
    {
        public ProductDto()
        {

        }
        public ProductDto(Guid? id, string name, bool composite,decimal costPrice, decimal salePrice, bool active , ProductType type)
        {
            Id = id;
            Name = name;
            Composite = composite;
            CostPrice = costPrice;
            SalePrice = salePrice;

            Type = type;
            Actived = active;
        }

        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Composite { get; set; }
        public ProductType Type { get; set; }
    }
}
