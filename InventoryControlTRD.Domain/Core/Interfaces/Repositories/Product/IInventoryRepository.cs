using InventoryControlTRD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Core.Interfaces.Repositories
{
    public interface IInventoryRepository : IBaseRepository<Inventory>
    {
        Task<IEnumerable<Inventory>> GetByProductIdAsync(Guid? id);
        void SubtractAmountList(IEnumerable<Inventory> inventoryList);
    }
}
