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

        /*
          public Guid ProductId { get; set; }
        public int Ammout { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
         */
        public InventoryRepository(IDataCore<Inventory> data)
        {
            _data = data;
        }

        public void AddAsync(Inventory obj)
        {
            _data.ExecuteAsync(@"insert into Inventory(ProductId,Ammout,Min,Max,CreatedOn,ModifiedOn,Active) 
                                 values(@CreatedOn,@ModifiedOn,@Active)", obj);
        }

        public Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return _data.QueryAsync(@"select * from Inventory");
        }

        public Task<Inventory> GetByIdAsync(Guid id)
        {
            return _data.QuerySingleAsync(@"select * from Inventory where Id = @ID ", new { @ID = id });
        }

        public void RemoveAsync(Inventory obj)
        {
            throw new NotImplementedException(); // Não irá ser permtido excluir inventário.
        }

        public void UpdateAsync(Inventory obj)
        {
            throw new NotImplementedException();
        }
    }
}
