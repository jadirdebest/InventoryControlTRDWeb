using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Infrastructure.Data.Core
{
    public interface IDataCore<T> where T: class
    {
        Task<IEnumerable<T>> QueryAsync(string query);
        Task<IEnumerable<T>> QueryAsync(string query, object obj);
        Task<T> QuerySingleAsync(string query, object obj);
        Task ExecuteAsync(string query);
        Task ExecuteMultipleAsync(string query, IEnumerable<object> objList);
        void Execute(string query,object obj);
        Task ExecuteAsync(string query,object obj);
    }
}
