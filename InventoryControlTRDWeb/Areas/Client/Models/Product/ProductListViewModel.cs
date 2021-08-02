using InventoryControlTRDWeb.Application.Dto;
using System.Collections.Generic;

namespace InventoryControlTRDWeb.Areas.Client.Models
{
    public class ProductListViewModel
    {

        public IEnumerable<ProductDto> ProductList { get; set; }


        public ProductListViewModel(IEnumerable<ProductDto> list) { ProductList = list; }
        public ProductListViewModel() { }

    }
}
