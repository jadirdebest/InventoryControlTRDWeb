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
    public class AppSubProductService : IAppSubProductService
    {
        private readonly IMapper _mapper;
        private readonly ISubProductService _subProductService;

        public AppSubProductService(IMapper mapper, ISubProductService subProductService)
        {
            _mapper = mapper;
            _subProductService = subProductService;
        }
        public async Task<IEnumerable<SubProductDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<SubProductDto>>(await _subProductService.GetAllAsync());
        }

        public async Task<SubProductDto> GetById(Guid id)
        {
            return _mapper.Map<SubProductDto>(await _subProductService.GetByIdAsync(id));
        }

        public async Task<IEnumerable<SubProductDto>> GetByProductId(Guid id)
        {
            return _mapper.Map<IEnumerable<SubProductDto>>(await _subProductService.GetSubProductsByProductIdAsync(id));
        }

        public Task Save(SubProductDto subProduct)
        {
            if (subProduct.Id == null) _subProductService.Add(_mapper.Map<SubProduct>(subProduct));
            else _subProductService.Update(_mapper.Map<SubProduct>(subProduct));

            return Task.CompletedTask;
        }
    }
}
