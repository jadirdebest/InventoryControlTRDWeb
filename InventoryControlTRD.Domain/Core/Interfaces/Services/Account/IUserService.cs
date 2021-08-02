using InventoryControlTRD.Domain.Models;
using System.Threading.Tasks;

namespace InventoryControlTRD.Domain.Core.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> GetByNickName(string nickName);
    }
}
