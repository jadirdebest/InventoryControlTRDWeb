using InventoryControlTRDWeb.Application.Dto;
using InventoryControlTRDWeb.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Client.Models
{
    public class RequestViewModel
    {
        public RequestViewModel(Guid? productId, Guid? userId, MovimentType movimentType)
        {
            ProductId = productId;
            UserId = userId;
            MovimentType = movimentType;
        }
        public RequestViewModel(IEnumerable<ProductDto> productList, IEnumerable<RequestProductDto> movimentProductList )
        {
            ProductList = productList;
            MovimentProductList = movimentProductList;
        }

        public RequestViewModel()
        {

        }
        public Guid? Id { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? UserId { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;
        public string TotalCostPrice { get => MovimentProductList != null ? MovimentProductList.Sum(a => a.SubTotalCostPrice).ToString("N2") : String.Empty ; }
        public string TotalSalePrice { get => MovimentProductList != null ? MovimentProductList.Sum(a => a.SubTotalSalePrice).ToString("N2") : String.Empty; }
        public int Amount { get; set; }
        public MovimentType MovimentType { get; set; }

        public IEnumerable<ProductDto> ProductList { get; set; }
        public IEnumerable<RequestProductDto> MovimentProductList { get; set; }

    }
}
