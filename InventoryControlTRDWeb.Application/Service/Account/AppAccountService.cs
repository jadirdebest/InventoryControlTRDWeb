using AutoMapper;
using InventoryControlTRD.Domain.Core.Interfaces.Services;
using InventoryControlTRD.Domain.Models;
using InventoryControlTRDWeb.Application.Dto;
using InventoryControlTRDWeb.Application.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Service
{
    public class AppAccountService : IAppAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAppSecurityService _securityService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AppAccountService(IMapper mapper, IAppSecurityService securityService, IUserService userService, IRoleService roleService)
        {
            _mapper = mapper;
            _securityService = securityService;
            _userService = userService;
            _roleService = roleService;
        }


        public void CreateAccount(AccountDto account)
        {
            _userService.Add(new User()
            {
                Id = Guid.NewGuid(),
                UserName = account.User.UserName,
                Password = _securityService.CreateMD5(account.User.Password),
                RoleId = account.User.RoleId
            });
        }

        public async Task<AccountDto> GetAccountNickName(string nickName)
        {
            var user = _mapper.Map<UserDto>(await _userService.GetByNickName(nickName));
            var role = _mapper.Map<RoleDto>(await _roleService.GetByIdAsync(user.RoleId));
            return new AccountDto()
            {
                User = user,
                Role = role
            };
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

        public async Task<IEnumerable<RoleDto>> GetAllRoles()
        {
            return _mapper.Map<IEnumerable<RoleDto>>(await _roleService.GetAllAsync());
        }

        public async Task<bool> LogonIsValid(UserDto user)
        {
            var userResponse = await _userService.GetByNickName(user.UserName);
            if (userResponse == null) return false;

            return _securityService.MD5IsMatch(user.Password, userResponse.Password);
        }

        public async Task<IEnumerable<UserDto>> GetAllAccounts()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _userService.GetAllAsync());
        }
    }
}
