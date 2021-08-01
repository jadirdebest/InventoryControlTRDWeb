using InventoryControlTRDWeb.Application.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Client.Controllers
{
    public class BaseController : Controller
    {
        protected void SetSession(string key,object obj)
        {
             base.HttpContext.Session.SetString(key,JsonSerializer.Serialize(obj));
        }
        protected string GetSession(string key)
        {
            return base.HttpContext.Session.GetString(key);
        }
    }
}
