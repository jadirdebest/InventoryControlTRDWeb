using InventoryControlTRDWeb.Application.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryControlTRDWeb.Areas.Manager.Models
{
    public class RegisterViewModel
    {
        public RegisterViewModel() { }
        public RegisterViewModel(IEnumerable<RoleDto> roleList) { RoleList = roleList; }
        public RegisterViewModel(IEnumerable<RoleDto> roleList, IEnumerable<UserDto> registerList)
        { RoleList = roleList; RegisterList = registerList; }

        public RegisterViewModel(int id, int userId, string nickName, Guid? roleProfile, IEnumerable<RoleDto> roleList)
        { Id = id; UserId = userId; NickName = nickName; RoleProfile = roleProfile; RoleList = roleList; }

        public int Id { get; set; }
        public int UserId { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Login")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Confirmar Senha")]
        [Compare(nameof(Password), ErrorMessage = "As senhas devem ser iguais")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Perfil de Acesso")]
        public Guid? RoleProfile { get; set; }


        public IEnumerable<RoleDto> RoleList { get; set; }
        public IEnumerable<UserDto> RegisterList { get; set; }
    }
}
