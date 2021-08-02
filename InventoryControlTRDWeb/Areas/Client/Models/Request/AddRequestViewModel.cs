using System;

namespace InventoryControlTRDWeb.Areas.Client.Models
{
    public class AddRequestViewModel
    {
        public Guid? ProductId { get; set; }
        public int Amount { get; set; }
    }
}
