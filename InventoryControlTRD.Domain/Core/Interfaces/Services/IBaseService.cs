using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Core.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        void Add(T obj);
        Task<T> GetByIdAsync(Guid? id);
        Task<IEnumerable<T>> GetAllAsync();
        void Update(T obj);
        void Remove(T obj);
    }
}
