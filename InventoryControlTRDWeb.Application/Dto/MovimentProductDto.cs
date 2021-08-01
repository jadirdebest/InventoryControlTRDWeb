﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Dto
{
    public class MovimentProductDto
    {
        public Guid? Id { get; set; }
        public Guid? ProductId { get; set; }
        public int Amount { get; set; }
        public decimal SubTotalCostPrice { get; set; }
        public decimal SubTotalSalePrice { get; set; }
    }
}
