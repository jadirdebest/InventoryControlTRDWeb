using InventoryControlTRD.Domain.Models;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Core.Interfaces.Repositories
{
    public interface IRequestRepository : IBaseRepository<Request>
    {
        Task<Request> AddWithReturnAsync(Request obj);
    }
}
