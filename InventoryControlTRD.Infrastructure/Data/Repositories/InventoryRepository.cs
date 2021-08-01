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
            return await _data.QueryAsync(@"select * from Inventory");
        }
        public async Task<Inventory> GetByIdAsync(Guid? id)
        {
            return await _data.QuerySingleAsync(@"select * from Inventory where Id = @ID ", new { @ID = id });
        }
        public async Task<Inventory> GetByProductIdAsync(Guid? id)
        {
            return await _data.QuerySingleAsync(@"select * from Inventory where ProductId = @ID ", new { @ID = id });
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
