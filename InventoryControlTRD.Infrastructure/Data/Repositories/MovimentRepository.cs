﻿using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Models;
using InventoryControlTRD.Infrastructure.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Infrastructure.Data.Repositories
{
    public class MovimentRepository : IBaseRepository<Moviment>, IMovimentRepository
    {
        private readonly IDataCore<Moviment> _data;

        /*
         * Id
          public Guid? UserId { get; set; }
        public decimal TotalCostPrice { get; set; }
        public decimal TotalSalePrice { get; set; }
        public int MovimentType { get; set; }
        CreatedOn
         */
        public MovimentRepository(IDataCore<Moviment> data)
        {
            _data = data;
        }

        public void AddAsync(Moviment obj)
        {
            throw new NotImplementedException();
        }

        public async Task<Moviment> AddWithReturnAsync(Moviment obj)
        {
            await _data.ExecuteAsync(@"insert into Moviment(Id,UserId,TotalCostPrice,TotalSalePrice,MovimentType,Date,CreatedOn) 
                                        values(@Id,@UserId,@TotalCostPrice,@TotalSalePrice,@MovimentType,@Date,sysdatetime())",obj);
            return obj;
        }

        public Task<IEnumerable<Moviment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Moviment> GetByIdAsync(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(Moviment obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Moviment obj)
        {
            throw new NotImplementedException();
        }
    }
}
