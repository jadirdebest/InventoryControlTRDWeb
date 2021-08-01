using InventoryControlTRDWeb.Application.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Client.Models
{
    public class SubProductViewModel
    {
       
        public Guid? Id { get; set; }
        public Guid? SubProductId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1,99999999)]
        public int Amount { get; set; }
        
        public ProductDto Product { get; set; }
        public IEnumerable<SubProductDto> SubProductList { get; set; }
        public IEnumerable<ProductDto> ProductList{ get; set; }

        public SubProductViewModel()
        {

        }

        public SubProductViewModel(ProductDto product, IEnumerable<ProductDto> productList, IEnumerable<SubProductDto> subProductList)
        {
            Product = product;
            ProductList = productList;
            SubProductList = subProductList;
        }
    }
}
