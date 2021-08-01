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
    public class SubProductService : BaseService<SubProduct>, ISubProductService
    {
        private readonly ISubProductRepository _repo;
        public SubProductService(ISubProductRepository repo) : base (repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<SubProduct>> GetSubProductsByProductIdAsync(Guid? id)
        {
            return await _repo.GetSubProductsByProductIdAsync(id);
        }
    }
}
