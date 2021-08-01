using InventoryControlTRDWeb.Application.Dto;
using InventoryControlTRDWeb.Application.Interface;
using InventoryControlTRDWeb.Areas.Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Client.Controllers
{
    [Area("Client")]
    public class RequestController : RequestBaseController
    {
        private readonly IAppProductService _productService;
        private readonly IAppInventoryService _inventoryService;
        private readonly IAppMovimentService _movimentService;
        
        
        public RequestController(IAppProductService productService, IAppInventoryService inventoryService, IAppMovimentService movimentService)
        {
            _productService = productService;
            _inventoryService = inventoryService;
            _movimentService = movimentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductMoviment(AddMovimentViewModel model)
        {
            try
            {
                var product = await _productService.GetById(model.ProductId);

                AddMovimentRequest(new MovimentProductDto()
                {
                    Amount = model.Amount,
                    Product = product,
                    SubTotalCostPrice = product.CostPrice * model.Amount,
                    SubTotalSalePrice = product.SalePrice * model.Amount
                });

                return Ok(new { success = true, message = "Adicionado com Sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

     
        public async Task<IActionResult> ProductRequest()
        {
            try
            {
                return View(new MovimentViewModel((await _productService.GetAllAsync()).Where(a => a.Actived) , MovimentProductList));
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> ProductRequest(MovimentViewModel model)
        {
            try
            {
                _movimentService.AddMoviment(new MovimentDto()
                {
                    Id = Guid.NewGuid(),
                    MovimentType = Application.Enums.MovimentType.Out,
                    UserId = Guid.Parse("F9FCC5A4-CA56-41B2-A189-A7E83ED13BB4"),
                    Date = model.Date,
                    MovimentProducts = MovimentProductList,
                });

                ClearMovimentRequest();
                ViewBag.Success = "Requisição Realizado com sucesso, os produtos requisitados já foram baixados do estoque";
                return View(new MovimentViewModel(await _productService.GetAllAsync(), MovimentProductList));
            }
            catch (Exception)
            {
                throw;
            }

        }


        public PartialViewResult ListProdutRequest()
        {
            return PartialView(MovimentProductList);
        }
    }
}
