using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryControlTRDWeb.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Administrator,Manager")]
    public class DashboardController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
