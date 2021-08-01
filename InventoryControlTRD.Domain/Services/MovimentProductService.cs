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
    public class MovimentProductService : BaseService<MovimentProduct> , IMovimentProductService
    {
        private readonly IMovimentProductRepository _repo;
        public MovimentProductService(IMovimentProductRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public void Add(IEnumerable<MovimentProduct> productlist)
        {
            _repo.Add(productlist);
        }
    }
}
