﻿using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repo;

        public BaseService(IBaseRepository<T> repo)
        {
            _repo = repo;
        }

        public virtual void AddAsync(T obj)
        {
            _repo.AddAsync(obj);
        }

        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public virtual Task<T> GetByIdAsync(int id)
        {
            return _repo.GetByIdAsync(id);
        }

        public virtual void RemoveAsync(T obj)
        {
            _repo.RemoveAsync(obj);
        }

        public virtual void UpdateAsync(T obj)
        {
            _repo.UpdateAsync(obj);
        }
    }
}