using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Models
{
    public class Product : Base
    {
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Type { get; set; }
    }
}
