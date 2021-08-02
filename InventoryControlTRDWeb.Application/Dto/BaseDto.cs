using System;

namespace InventoryControlTRDWeb.Application.Dto
{
    public abstract class BaseDto
    {
        public Guid? Id { get; set; }

        public bool Actived { get; set; }
    }
}
