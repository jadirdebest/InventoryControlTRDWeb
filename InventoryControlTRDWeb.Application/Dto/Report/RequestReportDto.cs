using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Dto
{
    public class RequestReportDto
    {
        public RequestReportDto(DateTime date, string productName,int amount,decimal totalCostPrice ,decimal totalSalePrice)
        {
            Date = date;
            ProductName = productName;
            Amount = amount;
            TotalCostPrice = totalCostPrice;
            TotalSalePrice = totalSalePrice;
        }

        public decimal TotalSalePrice { get; set; }
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public decimal TotalCostPrice { get; set; }

    }
}
