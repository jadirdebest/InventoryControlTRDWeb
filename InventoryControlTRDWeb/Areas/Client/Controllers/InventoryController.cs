using InventoryControlTRDWeb.Application.Dto;
using InventoryControlTRDWeb.Application.Interface;
using InventoryControlTRDWeb.Areas.Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Client.Controllers
{
    [Area("Client")]
    [Authorize(Roles = "Manager,User,Administrator")]
    public class InventoryController : Controller
    {
        private IAppInventoryService _inventoryService;
        private IAppProductService _productService;

        public InventoryController(IAppInventoryService inventoryService, IAppProductService productService)
        {
            _inventoryService = inventoryService;
            _productService = productService;
        }
        public async Task<IActionResult> List()
        {
            return View(new InventoryListViewModel(await _inventoryService.GetAllItensAsync()));
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                var simpleProductList = await _productService.GetAllSimpleProducts();

                return View(new InventoryViewModel(simpleProductList.Where(a => a.Actived)));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(InventoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.SimpleProductList = await _productService.GetAllSimpleProducts();
                    return View(model);
                }

                _inventoryService.AddItem(new InventoryDto(model.ProductId, model.Amount, model.Min, model.Max));
                return RedirectToAction("List");

            }
            catch (Exception ex)
            {
                model.SimpleProductList = await _productService.GetAllSimpleProducts();
                if (ex is ArgumentException)
                {
                    ViewBag.Info = ex.Message;
                }

                return View(model);
            }
        }
    }
}
