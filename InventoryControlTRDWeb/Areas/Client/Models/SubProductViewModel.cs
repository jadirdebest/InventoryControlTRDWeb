using InventoryControlTRDWeb.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Client.Models
{
    public class SubProductViewModel
    {
       
        public Guid? Id { get; set; }
        public Guid? SubProductId { get; set; }
        public int Amount { get; set; }
        
        public ProductDto Product { get; set; }
        public IEnumerable<SubProductDto> SubProductList { get; set; }

        public SubProductViewModel()
        {

        }

        public SubProductViewModel(ProductDto product, IEnumerable<SubProductDto> subProductList)
        {
            Product = product;
            SubProductList = subProductList;
        }
    }
}
