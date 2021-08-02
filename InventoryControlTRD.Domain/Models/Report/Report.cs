using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Models
{
    public class Report
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal CostTotal { get; set; }
        public decimal SaleTotal { get; set; }

    }
}
