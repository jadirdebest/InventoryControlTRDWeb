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
    public class MovimentProductRepository : IBaseRepository<MovimentProduct>, IMovimentProductRepository
    {
        private readonly IDataCore<MovimentProduct> _data;
        public MovimentProductRepository(IDataCore<MovimentProduct> data)
        {
            _data = data;
        }

        public async void Add(IEnumerable<MovimentProduct> productlist)
        {
            await _data.ExecuteMultipleAsync(@"insert into MovimentProduct(Id,ProductId,Amount,SubTotalCostPrice,SubTotalSalePrice)
                                       values(@Id,@ProductId,@Amount,@SubTotalCostPrice,@SubTotalSalePrice)", productlist);
        }

        public async void AddAsync(MovimentProduct obj)
        {
            await _data.ExecuteAsync(@"insert into MovimentProduct(Id,ProductId,Amount,SubTotalCostPrice,SubTotalSalePrice)
                                       values(@Id,@ProductId,@Amount,@SubTotalCostPrice,@SubTotalSalePrice)", obj);
        }

        public Task<IEnumerable<MovimentProduct>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MovimentProduct> GetByIdAsync(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(MovimentProduct obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(MovimentProduct obj)
        {
            throw new NotImplementedException();
        }
    }
}
