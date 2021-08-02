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
            return _data.QueryAsync(@"select xa.Id, xa.Name,xa.CostPrice,xa.SalePrice,xa.Type,1 as Amount,xa.Composite,xa.CreatedOn,xa.ModifiedOn,xa.Actived
                                        from Product xa
                                        where xa.Composite = 0 and xa.Id = @Id
                                      union 
                                        select xb.SubProductId as Id, xa.Name,xa.CostPrice,xa.SalePrice,xa.Type,xb.Amount,xa.Composite,xa.CreatedOn,xa.ModifiedOn,xa.Actived
                                        from Product xa
                                        inner join SubProduct xb on xa.Id = xb.SubProductId
                                        where xb.ProductId = @Id", new { Id = id });
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
