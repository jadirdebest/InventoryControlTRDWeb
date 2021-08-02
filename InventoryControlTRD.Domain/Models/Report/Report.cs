using System;

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
