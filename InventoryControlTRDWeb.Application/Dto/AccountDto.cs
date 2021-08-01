using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Dto
{
    public class AccountDto
    {
        public AccountDto(UserDto user)
        {
            User = user;
        }

        public AccountDto() { }
        public UserDto User { get; set; }
        public RoleDto Role { get; set; }
    }
}
