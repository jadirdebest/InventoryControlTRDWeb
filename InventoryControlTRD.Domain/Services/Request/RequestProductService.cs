using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Core.Interfaces.Services;
using InventoryControlTRD.Domain.Models;
using System.Collections.Generic;

namespace InventoryControlTRD.Domain.Services
{
    public class RequestProductService : BaseService<RequestProduct>, IRequestProductService
    {
        private readonly IRequestProductRepository _repo;
        public RequestProductService(IRequestProductRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public void Add(IEnumerable<RequestProduct> productlist)
        {
            _repo.Add(productlist);
        }

    }
}
