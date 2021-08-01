using InventoryControlTRDWeb.Application.Dto;
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
    public class ProductController : BaseController
    {
        private readonly IAppProductService _productService;
        private readonly IAppAccountService _appAccountService;
        public ProductController(IAppProductService productService, IAppAccountService appAccountService)
        {
            _productService = productService;
            _appAccountService = appAccountService;
        }

        public async Task<IActionResult> List() 
        {
            //SetSession(".listproduct", null);
            //_appAccountService.CreateAccount(new AccountDto()); //Isso ira sair

            ViewBag.Role = "Administrator";
            return View(new ProductListViewModel(await _productService.GetAllAsync())); 
        }
        public IActionResult Add() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ProductViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            
            try
            {
                _productService.Save(
                    new ProductDto(model.Id,model.Name,model.Composite,Decimal.Parse(model.CostPrice),Decimal.Parse(model.SalePrice),model.Active,model.Type));
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> Details(Guid id) 
        {
            try
            {
                return View(await _productService.GetById(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var product = await _productService.GetById(id);
                return View(new ProductViewModel(product.Id,product.Actived,product.Name,product.Composite,product.CostPrice.ToString(),product.SalePrice.ToString(),product.Type));
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
