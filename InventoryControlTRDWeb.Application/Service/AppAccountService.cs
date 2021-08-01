using AutoMapper;
using InventoryControlTRD.Domain.Core.Interfaces.Services;
using InventoryControlTRD.Domain.Models;
using InventoryControlTRDWeb.Application.Dto;
using InventoryControlTRDWeb.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Service
{
    public class AppAccountService : IAppAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AppAccountService(IMapper mapper, IUserService userService , IRoleService roleService )
        {
            _mapper = mapper;
            _userService = userService;
            _roleService = roleService;
        }


        public void CreateAccount(AccountDto user)
        {
            //_roleService.Add(new Role() { });
            _userService.Add(new User()
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                Password = "asdasdasdas",
                RoleId = Guid.Parse("1188C8F0-7FDC-4B13-A151-CBD0D06A47B8")
            });
        }

        public Task<RoleDto> GetRoleByNickName(string nickName)
        {
            throw new NotImplementedException();
        }

        public Task<RoleDto> GetRoleByUserId(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserByNickName(string nickName)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(AccountDto user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoleDto>> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogonIsValid(UserDto user)
        {
            throw new NotImplementedException();

            //var userResponse = await _serviceUser.GetByUserOrEmail(user.Email);
            //if (userResponse == null) return false;
            //return _md5Service.MD5IsMatch(user.Password, userResponse.Password);
        }
    }
}
