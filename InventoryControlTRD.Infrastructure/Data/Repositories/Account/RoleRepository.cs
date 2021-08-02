using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Models;
using InventoryControlTRD.Infrastructure.Data.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryControlTRD.Infrastructure.Data.Repositories
{
    public class RoleRepository : IBaseRepository<Role>, IRoleRepository
    {
        private IDataCore<Role> _data;

        public RoleRepository(IDataCore<Role> data)
        {
            _data = data;
        }
        public async void AddAsync(Role obj)
        {
            obj.Id = Guid.NewGuid();
            await _data.ExecuteAsync("insert into Role(Id,Name) values(@Id,@Name)", obj);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _data.QueryAsync("select * from Role");
        }

        public async Task<Role> GetByIdAsync(Guid? id)
        {
            var response = await _data.QuerySingleAsync("select * from Role where Id = @ID", new { ID = id });
            return response;
        }

        public void RemoveAsync(Role obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Role obj)
        {
            throw new NotImplementedException();
        }
    }
}
