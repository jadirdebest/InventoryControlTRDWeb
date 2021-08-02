using InventoryControlTRD.CrossCutting.Extensions;
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
    public class RequestController : RequestBaseController
    {
        private readonly IAppProductService _productService;
        private readonly IAppInventoryService _inventoryService;
        private readonly IAppRequestService _movimentService;


        public RequestController(IAppProductService productService, IAppInventoryService inventoryService, IAppRequestService movimentService)
        {
            _productService = productService;
            _inventoryService = inventoryService;
            _movimentService = movimentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductMoviment(AddRequestViewModel model)
        {
            try
            {
                var product = await _productService.GetById(model.ProductId);

                AddMovimentRequest(new RequestProductDto()
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
                return View(new RequestViewModel((await _productService.GetAllAsync()).Where(a => a.Actived), MovimentProductList));
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> ProductRequest(RequestViewModel model)
        {
            try
            {
                _movimentService.AddMoviment(new RequestDto()
                {
                    Id = Guid.NewGuid(),
                    MovimentType = Application.Enums.MovimentType.Out,
                    UserId = Guid.Parse(User.Identity.GetId()),
                    Date = model.Date,
                    MovimentProducts = MovimentProductList,
                });

                ClearMovimentRequest();
                ViewBag.Success = "Requisição Realizado com sucesso, os produtos requisitados já foram baixados do estoque";
                return View(new RequestViewModel(await _productService.GetAllAsync(), MovimentProductList));
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
