using InventoryControlTRDWeb.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Interface
{
    public interface IAppAccountService
    {
        void CreateAccount(AccountDto user);
        void RemoveUser(Guid? id);
        void UpdateUser(AccountDto user);
        Task<UserDto> GetUserById(Guid? id);
        Task<UserDto> GetUserByNickName(string nickName);

        Task<IEnumerable<RoleDto>> GetAllRoles();
        Task<bool> LogonIsValid(UserDto user);
        Task<RoleDto> GetRoleByUserId(Guid? id);
        Task<RoleDto> GetRoleByNickName(string nickName);
    }
}
