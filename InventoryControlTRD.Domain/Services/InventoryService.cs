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
    public class InventoryService : BaseService<Inventory>, IInventoryService
    {
        private readonly IInventoryRepository _repo;
        public InventoryService(IInventoryRepository repo) : base (repo)
        {
            _repo = repo;
        }
    }
}
