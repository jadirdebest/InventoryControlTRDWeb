using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Dto
{
    public class InventoryOutReportDto 
    {
        public InventoryOutReportDto(DateTime date, string productName, int amount, decimal totalCostPrice)
        {
            Date = date;
            ProductName = productName;
            Amount = amount;
            TotalCostPrice = totalCostPrice;
        }

        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public decimal TotalCostPrice { get; set; }
    }
}
