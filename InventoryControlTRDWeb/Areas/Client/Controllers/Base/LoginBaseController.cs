using InventoryControlTRDWeb.Config;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace InventoryControlTRDWeb.Areas.Client.Controllers
{
    [Area("Client")]
    public abstract class LoginBaseController : Controller
    {
        protected virtual async void SignIn(string Name, string Role, string UserId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Name),
                new Claim(ClaimTypes.Role, Role),
                new Claim(ClaimTypes.NameIdentifier,UserId)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await base.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity), AuthSettings.AuthProperties);
        }

        protected virtual async void SignOut()
        {
            await base.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
