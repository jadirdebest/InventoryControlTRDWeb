using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Client.Models
{
    public class AddMovimentViewModel
    {
        public Guid? ProductId { get; set; }
        public int Amount { get; set; }
    }
}
