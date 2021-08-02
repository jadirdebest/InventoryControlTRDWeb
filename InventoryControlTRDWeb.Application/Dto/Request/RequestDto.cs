using InventoryControlTRDWeb.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Dto
{
    public class RequestDto : BaseDto
    {
        public Guid ProductId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCostPrice { get => MovimentProducts != null ? MovimentProducts.Sum(a => a.SubTotalCostPrice) : 0; }
        public decimal TotalSalePrice { get => MovimentProducts != null ? MovimentProducts.Sum(a => a.SubTotalSalePrice) : 0; }
        public MovimentType MovimentType { get; set; }
        public IEnumerable<RequestProductDto> MovimentProducts { get; set; }
    }
}
