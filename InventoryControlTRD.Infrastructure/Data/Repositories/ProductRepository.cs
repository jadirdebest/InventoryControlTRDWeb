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
    public class ProductRepository : IBaseRepository<Product>, IProductRepository
    {
        private IDataCore<Product> _data;

        /*
          public Guid ProductId { get; set; }
        public int Ammout { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
         */
        public ProductRepository(IDataCore<Product> data)
        {
            _data = data;
        }
        public void AddAsync(Product obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(Product obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
