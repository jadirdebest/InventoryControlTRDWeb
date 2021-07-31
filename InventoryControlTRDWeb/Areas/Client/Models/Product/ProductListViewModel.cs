using InventoryControlTRDWeb.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Client.Models
{
    public class ProductListViewModel
    {

        public IEnumerable<ProductDto> ProductList { get; set; }


        public ProductListViewModel(IEnumerable<ProductDto> list) { ProductList = list; }
        public ProductListViewModel() { }

    }
}
