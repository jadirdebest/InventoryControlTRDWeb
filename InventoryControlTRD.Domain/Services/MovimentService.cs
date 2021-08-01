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
    public class MovimentService : BaseService<Moviment> , IMovimentService
    {
        private readonly IMovimentRepository _repo;

        public MovimentService(IMovimentRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public async  Task<Moviment> AddWithReturnAsync(Moviment obj)
        {
            return await _repo.AddWithReturnAsync(obj);
        }
     
    }
}
