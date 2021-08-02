using AutoMapper;
using InventoryControlTRD.Domain.Core.Interfaces.Services;
using InventoryControlTRD.Domain.Models;
using InventoryControlTRDWeb.Application.Dto;
using InventoryControlTRDWeb.Application.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Service
{
    public class AppProductService : IAppProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public AppProductService(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public void Save(ProductDto product)
        {
            if (product.Id == null) _productService.Add(_mapper.Map<Product>(product));
            else _productService.Update(_mapper.Map<Product>(product));

        }

        public async Task<ProductDto> GetById(Guid? id)
        {
            return _mapper.Map<ProductDto>(await _productService.GetByIdAsync(id));
        }
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productService.GetAllAsync());
        }

        public async Task<IEnumerable<ProductDto>> GetAllSimpleProducts()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productService.GetAllSimpleProducts());
        }
    }
}
