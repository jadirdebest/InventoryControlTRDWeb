using InventoryControlTRD.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Core.Interfaces.Services
{
    public interface IProductService : IBaseService<Product>
    {
        Task<IEnumerable<Product>> GetAllSimpleProducts();
    }
}
