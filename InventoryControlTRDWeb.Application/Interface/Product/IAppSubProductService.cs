using InventoryControlTRDWeb.Application.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Interface
{
    public interface IAppSubProductService
    {
        Task<IEnumerable<SubProductDto>> GetAllAsync();
        Task<SubProductDto> GetById(Guid id);
        Task<IEnumerable<SubProductDto>> GetByProductId(Guid id);
        Task Save(SubProductDto subProduct);
    }
}
