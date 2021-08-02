using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Models;
using InventoryControlTRD.Infrastructure.Data.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryControlTRD.Infrastructure.Data.Repositories
{
    public class ProductRepository : IBaseRepository<Product>, IProductRepository
    {
        private IDataCore<Product> _data;

        public ProductRepository(IDataCore<Product> data)
        {
            _data = data;
        }
        public async void AddAsync(Product obj)
        {
            obj.Id = Guid.NewGuid();
            await _data.ExecuteAsync(@"insert into Product(Id,Name,Composite,CostPrice,SalePrice,Type,Actived) 
                values(@Id,UPPER(@Name),@Composite,@CostPrice,@SalePrice,@Type,@Actived)", obj);
        }
        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return _data.QueryAsync(@"select * from Product");
        }

        public async Task<IEnumerable<Product>> GetAllSimpleProducts()
        {
            return await _data.QueryAsync(@"select * from Product where Composite =  0");
        }

        public Task<Product> GetByIdAsync(Guid? id)
        {
            return _data.QuerySingleAsync(@"select xa.Id, xa.Name,xa.CostPrice,xa.SalePrice,xa.Type,xa.Composite,xa.CreatedOn,xa.ModifiedOn,xa.Actived
                                            from Product xa
                                            where xa.Id = @Id
                                            union 
                                            select distinct xb.ProductId, xa.Name,(
                                            	select Sum(xa.CostPrice * xb.Amount)as CostPrice
                                            	from Product xa
                                            	inner join SubProduct xb on xa.Id = xb.SubProductId
                                            	where xb.ProductId =   @Id
                                            	group by xb.ProductId
                                            ) as CostPrice,xa.SalePrice,xa.Type,xa.Composite,xa.CreatedOn,xa.ModifiedOn,xa.Actived
                                            from Product xa
                                            inner join SubProduct xb on xa.Id = xb.ProductId
                                            where xb.ProductId = @Id
                                            order by CostPrice desc ", new { Id = id });
        }


        public async void RemoveAsync(Product obj)
        {
            await _data.ExecuteAsync("delete from Product where Id = @Id", obj);
        }
        public async void UpdateAsync(Product obj)
        {
            await _data.ExecuteAsync(@"update Product 
                                 set Name = @Name,
                                     CostPrice = @CostPrice,
                                     SalePrice = @SalePrice,
                                     Type = @Type,
                                     Actived = @Actived, 
                                     ModifiedOn = sysdatetime()
                                 where Id = @Id", obj );
        }
    }
}
