using InventoryControlTRD.Domain.Models;
using System.Collections.Generic;

namespace InventoryControlTRD.Domain.Core.Interfaces.Repositories
{
    public interface IRequestProductRepository : IBaseRepository<RequestProduct>
    {
        void Add(IEnumerable<RequestProduct> productlist);
    }
}
