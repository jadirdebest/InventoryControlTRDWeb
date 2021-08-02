using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Core.Interfaces.Services;
using InventoryControlTRD.Domain.Models;

namespace InventoryControlTRD.Domain.Services
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        private readonly IRoleRepository _repo;

        public RoleService(IRoleRepository repo) : base(repo)
        {

        }
    }
}
