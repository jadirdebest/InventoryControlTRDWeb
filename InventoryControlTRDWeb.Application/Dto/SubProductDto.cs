using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Dto
{
    public class SubProductDto
    {
        public Guid? Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid SubProductId { get; set; }
        public int Amount { get; set; }
    }
}
