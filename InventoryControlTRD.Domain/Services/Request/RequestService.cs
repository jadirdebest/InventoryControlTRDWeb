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
    public class RequestService : BaseService<Request> , IRequestService
    {
        private readonly IRequestRepository _repo;

        public RequestService(IRequestRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public async  Task<Request> AddWithReturnAsync(Request obj)
        {
            return await _repo.AddWithReturnAsync(obj);
        }
     
    }
}
