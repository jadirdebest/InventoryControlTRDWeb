using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Interface
{
    public interface IAppSecurityService
    {
        string CreateMD5(string word);
        bool MD5IsMatch(string word, string hash);
    }
}
