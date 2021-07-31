using InventoryControlTRDWeb.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Interface
{
    public interface IAppProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetById(Guid id);
        void Save(ProductDto product);
    }
}
