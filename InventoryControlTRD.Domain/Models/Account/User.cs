using System;

namespace InventoryControlTRD.Domain.Models
{
    public class User : Base
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid? RoleId { get; set; }
    }
}
