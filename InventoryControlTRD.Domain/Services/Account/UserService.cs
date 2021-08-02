using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Core.Interfaces.Services;
using InventoryControlTRD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public async Task<User> GetByNickName(string nickName)
        {
            return await _repo.GetByNickName(nickName);
        }
    }
}
