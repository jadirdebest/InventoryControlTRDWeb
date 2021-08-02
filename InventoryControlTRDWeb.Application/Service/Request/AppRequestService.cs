using AutoMapper;
using InventoryControlTRD.Domain.Core.Interfaces.Services;
using InventoryControlTRD.Domain.Models;
using InventoryControlTRDWeb.Application.Dto;
using InventoryControlTRDWeb.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Service
{
    public class AppRequestService : IAppRequestService
    {
        private readonly IMapper _mapper;
        private readonly IRequestService _movimentService;
        private readonly IRequestProductService _movimentProductService;
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly ISubProductService _subProductService;

        public AppRequestService(
            IMapper mapper, 
            IRequestService movimentService, 
            IRequestProductService movimentProductService, 
            IInventoryService inventoryService,
            IProductService productService,
            ISubProductService subProductService
            )
        {
            _mapper = mapper;
            _movimentService = movimentService;
            _movimentProductService = movimentProductService;
            _inventoryService = inventoryService;
            _productService = productService;
            _subProductService = subProductService;
        }

        public void AddMoviment(RequestDto obj)
        {
            try
            {
                var id = CreateNewMoviment(obj);
                AddProductsInMoviment(obj,id);
                UpdateInventory(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Guid? CreateNewMoviment(RequestDto obj)
        {
            var moviment = _movimentService.AddWithReturnAsync(_mapper.Map<Request>(obj)).Result;
            if (moviment == null) throw new Exception("A movimentação de estoque não foi realizado");
            return moviment.Id;
        }
        private void AddProductsInMoviment(RequestDto obj,Guid? id)
        {
            _movimentProductService.Add(GetMovimenProductList(obj,id));
        }
        private void UpdateInventory(RequestDto obj)
        {
            List<Inventory> InventoryProductsUpdateList = new List<Inventory>();

            foreach (var mvProduct in obj.MovimentProducts)
            {
                var subProducts = _subProductService.GetSubProductsByProductIdAsync(mvProduct.Product.Id).Result;
                foreach(var product in subProducts) 
                    InventoryProductsUpdateList.Add(new Inventory() { ProductId = product.Id, Amount = mvProduct.Amount * product.Amount });
            }

            _inventoryService.SubtractAmountList(InventoryProductsUpdateList);
        }
        private IEnumerable<RequestProduct> GetMovimenProductList (RequestDto moviment,Guid? id)
        {
            foreach (var item in moviment.MovimentProducts)
                yield return new RequestProduct()
                {
                    Id = id,
                    Amount = item.Amount,
                    ProductId = item.Product.Id,
                    SubTotalCostPrice = item.SubTotalCostPrice,
                    SubTotalSalePrice = item.SubTotalSalePrice
                };
        }
    }
}
