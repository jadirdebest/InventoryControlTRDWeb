using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Dto
{
    public class InventoryDto : BaseDto
    {
        public Guid ProductId { get; set; }
        public int Ammout { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
