using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
