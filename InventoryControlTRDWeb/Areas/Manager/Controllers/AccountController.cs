using InventoryControlTRDWeb.Application.Dto;
using InventoryControlTRDWeb.Application.Interface;
using InventoryControlTRDWeb.Areas.Manager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Administrator,Manager")]
    public class AccountController : Controller
    {
        private readonly IAppAccountService _serviceAccount;

        public AccountController(IAppAccountService serviceAccount)
        {
            _serviceAccount = serviceAccount;
        }

        public async Task<IActionResult> Register()
        {
            try
            {
                var listRole = await _serviceAccount.GetAllRoles();
                var listRegister = await _serviceAccount.GetAllAccounts();
                return View(new RegisterViewModel(listRole, listRegister));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                _serviceAccount.CreateAccount(
                    new AccountDto(new UserDto(model.NickName, model.Password, model.RoleProfile)));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return RedirectToAction("Register", "Account");
        }
    }
}
