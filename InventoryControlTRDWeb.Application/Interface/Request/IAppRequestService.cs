using InventoryControlTRDWeb.Application.Dto;

namespace InventoryControlTRDWeb.Application.Interface
{
    public interface IAppRequestService
    {
        void AddMoviment(RequestDto obj);
    }
}
