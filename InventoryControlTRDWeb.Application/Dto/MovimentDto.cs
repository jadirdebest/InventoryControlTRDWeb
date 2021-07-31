using InventoryControlTRDWeb.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Dto
{
    public class MovimentDto : BaseDto
    {
        public Guid ProductId { get; set; }
        public int Ammout { get; set; }
        public decimal SubTotalCostPrice { get; set; }
        public decimal SubTotalSalePrice { get; set; }
        public MovimentType MovimentType { get; set; }
    }
}
