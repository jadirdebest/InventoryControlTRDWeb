﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Dto
{
    public class UserDto : BaseDto
    {
        public UserDto(string userName, string password, Guid? roleId)
        {
            UserName = userName;
            Password = password;
            RoleId = roleId;
        }

        public UserDto(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid? RoleId { get; set; }
    }
}
