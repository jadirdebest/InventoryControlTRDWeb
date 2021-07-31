using InventoryControlTRDWeb.Application.Interface;
using InventoryControlTRDWeb.Areas.Client.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Client.Controllers
{
    [Area("Client")]
    public class SubProductController : Controller
    {
        private readonly IAppProductService _productService;
        private readonly IAppSubProductService _subProductService;
        public SubProductController(IAppProductService productService, IAppSubProductService subProductService)
        {
            _productService = productService;
            _subProductService = subProductService;
        }
        public async Task<IActionResult> Add(Guid idProduct)
        {
            try
            {
                var product = await _productService.GetById(idProduct);
                var listSubProducts = await _subProductService.GetByProductId(idProduct);
                return View(new SubProductViewModel(product,listSubProducts));
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
