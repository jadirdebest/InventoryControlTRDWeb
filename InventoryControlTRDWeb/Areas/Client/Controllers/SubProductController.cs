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
                var listProducts = (await _productService.GetAllAsync()).Where(a => !a.Composite);
                var listSubProducts = await _subProductService.GetByProductId(idProduct);
                return View(new SubProductViewModel(product, listProducts, listSubProducts));
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(SubProductViewModel subProduct)
        {
            try
            {
                await _subProductService.Save(new SubProductDto(subProduct.Product.Id, subProduct.SubProductId, subProduct.Amount));


                return RedirectToAction("Add", new { idProduct = subProduct.Product.Id });
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
