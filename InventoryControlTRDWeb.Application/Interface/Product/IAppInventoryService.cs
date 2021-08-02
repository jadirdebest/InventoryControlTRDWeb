using InventoryControlTRDWeb.Application.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Interface
{
    public interface IAppInventoryService
    {
        Task<IEnumerable<InventoryDto>> GetAllItensAsync();
        Task<IEnumerable<InventoryDto>> GetItembyProducuId(Guid? id);
        void AddItem(InventoryDto inventory);
    }
}
