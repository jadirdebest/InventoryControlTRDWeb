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

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid? id)
        {
            throw new NotImplementedException();
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
