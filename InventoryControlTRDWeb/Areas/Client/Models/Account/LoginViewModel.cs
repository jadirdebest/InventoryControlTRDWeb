using System.ComponentModel.DataAnnotations;

namespace InventoryControlTRDWeb.Areas.Client.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Password { get; set; }

    }
}
