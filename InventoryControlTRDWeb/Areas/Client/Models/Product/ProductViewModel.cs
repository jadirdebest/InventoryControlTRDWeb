using InventoryControlTRDWeb.Application.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Client.Models
{
    public class ProductViewModel
    {
        public Guid? Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public bool Composite { get; set; }

        [DataType(DataType.Currency)]
        public string CostPrice { get; set; }
        public string SalePrice { get; set; }
        public ProductType Type { get; set; }

        public ProductViewModel()
        {

        }

        public ProductViewModel(Guid? id, bool active, string name,bool composite ,string costPrice, string salePrice, ProductType type)
        {
            Id = id;
            Active = active;
            Composite = composite;
            Name = name;
            CostPrice = costPrice;
            SalePrice = salePrice;
            Type = type;
        }
    }
}
