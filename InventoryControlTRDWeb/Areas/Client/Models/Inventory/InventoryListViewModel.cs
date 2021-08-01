using InventoryControlTRDWeb.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
