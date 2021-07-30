using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Dto
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
    }
}
