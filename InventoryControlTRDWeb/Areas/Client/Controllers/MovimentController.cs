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
    public class MovimentController : BaseController
    {
        private readonly IAppProductService _productService;
        private readonly IAppMovimentService _movimentService;
        private List<MovimentProductDto> MovimentProductList;
        
        public MovimentController(IAppProductService productService, IAppMovimentService movimentService)
        {
            _productService = productService;
            _movimentService = movimentService;
        }

        private void LoadList()
        {
            MovimentProductList = GetSession(".listproduct") == null ? 
                new List<MovimentProductDto>() :  
                JsonSerializer.Deserialize<List<MovimentProductDto>>(GetSession(".listproduct"));
        }

        [HttpPost]
        public async Task<IActionResult> AddProductMoviment(MovimentViewModel model)
        {
            try
            {
                LoadList();
                var product = await _productService.GetById(model.ProductId);
                
                MovimentProductList.Add(new MovimentProductDto()
                {
                    Amount = model.Amount,
                    ProductId = product.Id,
                    SubTotalCostPrice = product.CostPrice * model.Amount,
                    SubTotalSalePrice = product.SalePrice * model.Amount
                });

                SetSession(".listproduct", MovimentProductList);

                model.ProductList = await _productService.GetAllAsync();
                model.MovimentProductList = MovimentProductList;

                return View("ProductRequest",model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

     
        public async Task<IActionResult> ProductRequest()
        {
            try
            {
                LoadList();
                return View(new MovimentViewModel(await _productService.GetAllAsync() , MovimentProductList));
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
                LoadList();

                _movimentService.AddMoviment(new MovimentDto()
                {
                    Id = Guid.NewGuid(),
                    MovimentType = Application.Enums.MovimentType.Out,
                    UserId = Guid.Parse("F9FCC5A4-CA56-41B2-A189-A7E83ED13BB4"),
                    Date = model.Date,
                    MovimentProducts = MovimentProductList,
                });

                return View(new MovimentViewModel(await _productService.GetAllAsync(), MovimentProductList));
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
