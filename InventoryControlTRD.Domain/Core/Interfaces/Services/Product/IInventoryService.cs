using InventoryControlTRD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Core.Interfaces.Services
{
    public interface IInventoryService : IBaseService<Inventory>
    {
        Task<Inventory> GetByProductIdAsync(Guid id);
        void SubtractAmountList(IEnumerable<Inventory> list);
    }
}
