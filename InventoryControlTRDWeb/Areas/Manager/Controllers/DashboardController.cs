using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
