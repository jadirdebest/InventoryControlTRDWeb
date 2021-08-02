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
    public class UserRepository : IBaseRepository<User>, IUserRepository
    {
        private IDataCore<User> _data;

        public UserRepository(IDataCore<User> data)
        {
            _data = data;
        }
        public void AddAsync(User obj)
        {
            _data.Execute("insert into \"User\"(Id,UserName,Password,RoleId) values(@Id,@UserName,@Password,@RoleId)",obj);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _data.QueryAsync("select * from \"User\"");
        }

        public Task<User> GetByIdAsync(Guid? id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByNickName(string nickName)
        {
            return await _data.QuerySingleAsync("select * from \"User\" where UserName = @Nick",new {Nick = nickName});
        }

        public void RemoveAsync(User obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
