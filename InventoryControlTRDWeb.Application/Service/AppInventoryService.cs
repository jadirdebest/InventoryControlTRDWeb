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
            return _mapper.Map<IEnumerable<InventoryDto>>(await _inventoryService.GetAllAsync());
        }
    }
}
