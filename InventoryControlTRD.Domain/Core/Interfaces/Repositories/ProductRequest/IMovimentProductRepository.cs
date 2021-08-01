﻿using InventoryControlTRD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Core.Interfaces.Repositories
{
    public interface IMovimentProductRepository : IBaseRepository<MovimentProduct>
    {
        void Add(IEnumerable<MovimentProduct> productlist);
    }
}
