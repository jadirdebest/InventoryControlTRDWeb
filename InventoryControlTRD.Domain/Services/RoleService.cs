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
    public class RoleService : BaseService<Role>, IRoleService
    {
        private readonly IRoleRepository _repo;

        public RoleService(IRoleRepository repo) : base(repo)
        {

        }
    }
}
