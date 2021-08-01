using InventoryControlTRDWeb.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Interface
{
    public interface IAppInventoryService
    {
        Task<IEnumerable<InventoryDto>> GetAllItensAsync();
        void AddItem(InventoryDto inventory);
    }
}
