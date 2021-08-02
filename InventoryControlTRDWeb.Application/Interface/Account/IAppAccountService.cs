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
        Task<AccountDto> GetAccountNickName(string nickName);
        Task<IEnumerable<RoleDto>> GetAllRoles();
        Task<IEnumerable<UserDto>> GetAllAccounts();
        Task<bool> LogonIsValid(UserDto user);
    }
}
