using InventoryControlTRDWeb.Application.Dto;
using InventoryControlTRDWeb.Application.Interface;
using InventoryControlTRDWeb.Areas.Client.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Client.Controllers
{
    [Area("Client")]
    public class LoginController : LoginBaseController
    {
        private readonly IAppAccountService _serviceAccount;

        public LoginController(IAppAccountService serviceAccount)
        {
            _serviceAccount = serviceAccount;
        }

        public IActionResult Logon(string ReturnUrl, bool denied = false)
        {
            if (User.Identity.IsAuthenticated && !denied) return RedirectToAction("List", "Product");

            if (denied) ViewBag.Error = "Acesso Negado, é necessário um usuario com este previlégio";
            ViewBag.ReturnUrl = ReturnUrl;

            return View();
        }

        public IActionResult DeniedLogon(string ReturnUrl)
        {
            return RedirectToAction("Logon", new { denied = true, ReturnUrl = ReturnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logon(LoginViewModel model, string ReturnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            ViewBag.ReturnUrl = ReturnUrl;

            if (model.Login.Equals("admin") && model.Password.Equals("admin"))
            {
                SignIn("admin", "Administrator");
                if (string.IsNullOrEmpty(ReturnUrl)) return RedirectToAction("Books", "Book");
                return Redirect(ReturnUrl);
            }
          
            var acessGranted = await _serviceAccount.LogonIsValid(new UserDto(model.Login, model.Password));
            if (!acessGranted)
            {
                ModelState.AddModelError("Password", "Usuário ou senha incorretos");
                return View(model);
            }

          
            var roleProfile = await _serviceAccount.GetRoleByNickName(model.Login);

            //Eu criei uma classe Abstrata herdado por essa classe que contém esse método, isso facilita bastante, quando é preciso utilizar mais de uma vez
            //o método, fora que deixa o código mais limpo
            SignIn(model.Login, roleProfile.Name);

            if (string.IsNullOrEmpty(ReturnUrl)) return RedirectToAction("Books", "Book");
            return Redirect(ReturnUrl);
        }

        public IActionResult Logout()
        {
            SignOut();
            return RedirectToAction("Logon");
        }
    }
}
