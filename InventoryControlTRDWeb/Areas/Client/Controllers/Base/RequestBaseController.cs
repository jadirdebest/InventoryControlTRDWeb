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
    public class RequestBaseController : Controller
    {
        protected List<MovimentProductDto> MovimentProductList
        {
            get => GetListSessionRequest();
            set => SetListSessionRequest(value);
        }

        protected void AddMovimentRequest(MovimentProductDto request)
        {
            var temp = MovimentProductList;
            temp.Add(request);
            MovimentProductList = temp;
        }

        protected void ClearMovimentRequest()
        {
            var temp = MovimentProductList;
            temp.Clear();
            MovimentProductList = temp;
        }
        private List<MovimentProductDto> GetListSessionRequest()
        {
            return GetSession(".listproduct") == null ?
              new List<MovimentProductDto>() :
              JsonSerializer.Deserialize<List<MovimentProductDto>>(GetSession(".listproduct"));
        }

        private void SetListSessionRequest(List<MovimentProductDto> list)
        {
            SetSession(".listproduct", list);
        }

        private void SetSession(string key,object obj)
        {
             base.HttpContext.Session.SetString(key,JsonSerializer.Serialize(obj));
        }
        private string GetSession(string key)
        {
            return base.HttpContext.Session.GetString(key);
        }
    }
}
