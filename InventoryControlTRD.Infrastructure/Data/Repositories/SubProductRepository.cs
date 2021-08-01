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
    public class SubProductRepository : IBaseRepository<SubProduct>, ISubProductRepository
    {
        private IDataCore<SubProduct> _data;

        public SubProductRepository(IDataCore<SubProduct> data)
        {
            _data = data;
        }
        public async void AddAsync(SubProduct obj)
        {
            obj.Id = Guid.NewGuid();
            await _data.ExecuteAsync(@"insert into SubProduct(Id,ProductId,SubProductId,Amount) values(@Id,@ProductId,@SubProductId,@Amount)",obj);
        }

        public async Task<IEnumerable<SubProduct>> GetAllAsync()
        {
             return await _data.QueryAsync(@"select * from SubProduct");
        }

        public async Task<SubProduct> GetByIdAsync(Guid? id)
        { 
            return await _data.QuerySingleAsync(@"select * from SubProduct where Id = @Id", new { Id = id });
        }

        public Task<IEnumerable<SubProduct>> GetSubProductsByProductIdAsync(Guid? id)
        {
            return _data.QueryAsync(@"select * from SubProduct where ProductId = @Id", new { Id = id });
        }

        public async void RemoveAsync(SubProduct obj)
        {
            await _data.ExecuteAsync(@"delete from SubProduct where Id = @Id",obj);
        }

        public async void UpdateAsync(SubProduct obj)
        {
            await _data.ExecuteAsync(@"update SubProduct set ProductId = @ProductId, SubProductId = @SubProductId, @Ammout = @Ammout where Id = @Id", obj);
        }
    }
}
