using InventoryControlTRD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Core.Interfaces.Repositories
{
    public interface ISubProductRepository : IBaseRepository<SubProduct>
    {
        Task<IEnumerable<SubProduct>> GetSubProductsByProductIdAsync(Guid? id);
    }
}
