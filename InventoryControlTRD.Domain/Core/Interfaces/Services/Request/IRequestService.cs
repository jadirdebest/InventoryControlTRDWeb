using InventoryControlTRD.Domain.Models;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Core.Interfaces.Services
{
    public interface IRequestService : IBaseService<Request>
    {
        Task<Request> AddWithReturnAsync(Request obj);
    }
}
