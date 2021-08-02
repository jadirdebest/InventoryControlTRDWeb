using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Models;
using InventoryControlTRD.Infrastructure.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Infrastructure.Data.Repositories
{
    public class RequestProductRepository : IBaseRepository<RequestProduct>, IRequestProductRepository
    {
        private readonly IDataCore<RequestProduct> _data;
        public RequestProductRepository(IDataCore<RequestProduct> data)
        {
            _data = data;
        }

        public async void Add(IEnumerable<RequestProduct> productlist)
        {
            await _data.ExecuteMultipleAsync(@"insert into RequestProduct(Id,ProductId,Amount,SubTotalCostPrice,SubTotalSalePrice)
                                       values(@Id,@ProductId,@Amount,@SubTotalCostPrice,@SubTotalSalePrice)", productlist);
        }

        public async void AddAsync(RequestProduct obj)
        {
            await _data.ExecuteAsync(@"insert into RequestProduct(Id,ProductId,Amount,SubTotalCostPrice,SubTotalSalePrice)
                                       values(@Id,@ProductId,@Amount,@SubTotalCostPrice,@SubTotalSalePrice)", obj);
        }

        public Task<IEnumerable<RequestProduct>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RequestProduct> GetByIdAsync(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(RequestProduct obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(RequestProduct obj)
        {
            throw new NotImplementedException();
        }
    }
}
