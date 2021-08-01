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
            try
            {
                if (!ModelState.IsValid) return View(model);

                ViewBag.ReturnUrl = ReturnUrl;

                //Apenas para facilitar o login
                if (model.Login.Equals("admin") && model.Password.Equals("admin"))
                {
                    SignIn("admin", "Administrator", "F9FCC5A4-CA56-41B2-A189-A7E83ED13BB4");
                    return Redirect("/Manager/Dashboard/Home");
                }

                var acessGranted = await _serviceAccount.LogonIsValid(new UserDto(model.Login, model.Password));
                if (!acessGranted)
                {
                    ModelState.AddModelError("Password", "Usuário ou senha incorretos");
                    return View(model);
                }


                var account = await _serviceAccount.GetAccountNickName(model.Login);
                SignIn(model.Login, account.User.UserName,account.User.Id.ToString());

                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    switch (account.Role.Name)
                    {
                        case "Manager": return Redirect("Manager/DashBoard/Home");
                        case "Administrator": return Redirect("Manager/DashBoard/Home");
                        default: return RedirectToAction("List", "Product");
                    }
                }

                return Redirect(ReturnUrl);
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public IActionResult Logout()
        {
            SignOut();
            return RedirectToAction("Logon");
        }
    }
}
