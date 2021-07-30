using InventoryControlTRD.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Models
{
    public class Moviment : Base
    {
        public Guid ProductId { get; set; }
        public int Ammout { get; set; }
        public decimal SubTotalCostPrice { get; set; }
        public decimal SubTotalSalePrice { get; set; }
        public MovimentType MovimentType { get; set; }
    }
}
