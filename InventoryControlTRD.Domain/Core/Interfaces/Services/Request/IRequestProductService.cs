using InventoryControlTRD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Core.Interfaces.Services
{
    public interface IRequestProductService : IBaseService<RequestProduct>
    {
        void Add(IEnumerable<RequestProduct> productlist);
        
    }
}
