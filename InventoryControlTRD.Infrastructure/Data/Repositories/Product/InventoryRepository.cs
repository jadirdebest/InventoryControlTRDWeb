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
    public class InventoryRepository : IBaseRepository<Inventory>, IInventoryRepository
    {
        private IDataCore<Inventory> _data;
        public InventoryRepository(IDataCore<Inventory> data)
        {
            _data = data;
        }

        public async void AddAsync(Inventory obj)
        {
            obj.Id = Guid.NewGuid();
            await _data.ExecuteAsync(@"insert into Inventory(Id,ProductId,Amount,Min,Max,CreatedOn,Actived) 
                                 values(@Id,@ProductId,@Amount,@Min,@Max,sysdatetime(),@Actived)", obj);
        }
        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await _data.QueryAsync<Product>(@"select * from Inventory xa inner join Product xb on xa.ProductId = xb.Id",
                (inventory,product) =>
                {
                    inventory.Product = product;
                    return inventory;
                });
        }
        public async Task<Inventory> GetByIdAsync(Guid? id)
        {
            return await _data.QuerySingleAsync(@"select * from Inventory where Id = @ID ", new { @ID = id });
        }
        public async Task<IEnumerable<Inventory>> GetByProductIdAsync(Guid? id)
        {
            //Testar
            return await _data.QueryAsync(@"select  xa.Id, xa.Amount,xa.Min,xa.Max 
                        from Inventory xa 
                        inner join Product xc on xc.Id = xa.ProductId
                        left join SubProduct xb on xa.Productid = xb.SubProductID  
                        where xa.ProductId = @ID or xb.ProductId = @ID",
                        new { @ID = id });
        }
        public void RemoveAsync(Inventory obj)
        {
            throw new NotImplementedException(); // Não irá ser permtido excluir inventário.
        }
        public async void SubtractAmountList(IEnumerable<Inventory> inventoryList)
        {
            await _data.ExecuteMultipleAsync("update Inventory set Amount = Amount - @Amount where ProductId = @ProductId", inventoryList);
        }
        public void UpdateAsync(Inventory obj)
        {
            throw new NotImplementedException();
        }
    }
}
