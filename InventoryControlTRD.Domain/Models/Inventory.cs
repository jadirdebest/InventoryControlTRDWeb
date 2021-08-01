using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Models
{
    public class Inventory : Base
    {
        public Guid? ProductId { get; set; }
        public int Amount { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
