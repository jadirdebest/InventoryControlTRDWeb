using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Core.Interfaces.Services;
using InventoryControlTRD.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Product>> GetAllSimpleProducts()
        {
            return _repo.GetAllSimpleProducts();
        }
    }
}
