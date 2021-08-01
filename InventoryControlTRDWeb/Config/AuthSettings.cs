using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Config
{
    public class AuthSettings
    {
        public static AuthenticationProperties AuthProperties { get => GetAuthProperties(); }

        private static AuthenticationProperties GetAuthProperties()
        {
            var authPropiets = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(15),
                IsPersistent = true, 
            };

            return authPropiets;
        }
    }
}
