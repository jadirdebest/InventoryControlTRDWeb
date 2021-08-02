using InventoryControlTRDWeb.Application.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace InventoryControlTRDWeb.Areas.Client.Controllers
{
    public class RequestBaseController : Controller
    {
        protected List<RequestProductDto> MovimentProductList
        {
            get => GetListSessionRequest();
            set => SetListSessionRequest(value);
        }

        protected void AddMovimentRequest(RequestProductDto request)
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
        private List<RequestProductDto> GetListSessionRequest()
        {
            return GetSession(".listproduct") == null ?
              new List<RequestProductDto>() :
              JsonSerializer.Deserialize<List<RequestProductDto>>(GetSession(".listproduct"));
        }

        private void SetListSessionRequest(List<RequestProductDto> list)
        {
            SetSession(".listproduct", list);
        }

        private void SetSession(string key, object obj)
        {
            base.HttpContext.Session.SetString(key, JsonSerializer.Serialize(obj));
        }
        private string GetSession(string key)
        {
            return base.HttpContext.Session.GetString(key);
        }
    }
}
