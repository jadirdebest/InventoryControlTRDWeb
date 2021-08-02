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
    public class AppInventoryService : IAppInventoryService
    {
        private readonly IMapper _mapper;
        private readonly IInventoryService _inventoryService;
        public AppInventoryService(IMapper mapper, IInventoryService inventoryService)
        {
            _mapper = mapper;
            _inventoryService = inventoryService;
        }

        public void AddItem(InventoryDto inventoryDto)
        {
            _inventoryService.Add(_mapper.Map<Inventory>(inventoryDto));
        }

        public async Task<IEnumerable<InventoryDto>> GetAllItensAsync()
        {
            var products = await _inventoryService.GetAllAsync();
            return _mapper.Map<IEnumerable<InventoryDto>>(products);
        }

        public async Task<IEnumerable<InventoryDto>> GetItembyProducuId(Guid? id)
        {
            return _mapper.Map<IEnumerable<InventoryDto>>(await _inventoryService.GetByProductIdAsync(id));
        }
    }
}
