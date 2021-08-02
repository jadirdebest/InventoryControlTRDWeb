using InventoryControlTRD.Domain.Models;
using System.Collections.Generic;

namespace InventoryControlTRD.Domain.Core.Interfaces.Services
{
    public interface IRequestProductService : IBaseService<RequestProduct>
    {
        void Add(IEnumerable<RequestProduct> productlist);

    }
}
