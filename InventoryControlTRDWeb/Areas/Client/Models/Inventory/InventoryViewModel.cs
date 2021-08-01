using InventoryControlTRDWeb.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Client.Models
{
    public class InventoryViewModel
    {
        public Guid? ProductId { get; set; }
        public int Amount { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public IEnumerable<ProductDto> SimpleProductList { get; set; }


        public InventoryViewModel(IEnumerable<ProductDto> simpleProductList)
        {
            SimpleProductList = simpleProductList;
        }
        public InventoryViewModel()
        {

        }
    }
}
