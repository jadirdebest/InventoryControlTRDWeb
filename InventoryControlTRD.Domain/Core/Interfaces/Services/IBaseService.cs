using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Core.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        void AddAsync(T obj);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        void UpdateAsync(T obj);
        void RemoveAsync(T obj);
    }
}
