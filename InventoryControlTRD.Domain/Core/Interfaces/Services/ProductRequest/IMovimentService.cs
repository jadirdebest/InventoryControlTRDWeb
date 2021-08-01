using InventoryControlTRD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Core.Interfaces.Services
{
    public interface IMovimentService : IBaseService<Moviment>
    {
        Task<Moviment> AddWithReturnAsync(Moviment obj);
    }
}
