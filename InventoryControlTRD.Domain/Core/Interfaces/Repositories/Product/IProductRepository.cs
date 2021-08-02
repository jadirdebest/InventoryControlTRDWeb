using InventoryControlTRD.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Core.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllSimpleProducts();
    }
}
