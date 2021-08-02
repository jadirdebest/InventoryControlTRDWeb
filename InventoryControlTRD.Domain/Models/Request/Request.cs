using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Models
{
    public class Request : Base
    {
        public Guid? UserId { get; set; }
        public decimal TotalCostPrice { get; set; }
        public decimal TotalSalePrice { get; set; }
        public DateTime Date { get; set; }
        public int MovimentType { get; set; }
    }
}
