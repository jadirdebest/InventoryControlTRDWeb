using InventoryControlTRDWeb.Application.Dto;
using System.Collections.Generic;

namespace InventoryControlTRDWeb.Areas.Client.Models
{
    public class InventoryListViewModel
    {
        public IEnumerable<InventoryDto> InventoryList { get; set; }

        public InventoryListViewModel(IEnumerable<InventoryDto> inventoryList)
        {
            InventoryList = inventoryList;
        }
    }
}
