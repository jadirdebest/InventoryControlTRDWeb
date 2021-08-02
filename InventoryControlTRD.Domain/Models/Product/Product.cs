namespace InventoryControlTRD.Domain.Models
{
    public class Product : Base
    {
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool Composite { get; set; }
        public int Type { get; set; }
    }
}
