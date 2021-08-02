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

        public override void Add(Inventory obj)
        {
            //var itemExist = _repo.GetByProductIdAsync(obj.ProductId).Result;
            var itemExist = _repo.GetByProductIdAsync(obj.Product.Id).Result;
            if (itemExist != null) throw new ArgumentException("Este produto já foi adicionado ao Estoque");

             _repo.AddAsync(obj);
        }

        public async Task<IEnumerable<Inventory>> GetByProductIdAsync(Guid? id)
        {
            return await _repo.GetByProductIdAsync(id);
        }

        public void SubtractAmountList(IEnumerable<Inventory> list)
        {
            _repo.SubtractAmountList(list);
        }
    }
}
