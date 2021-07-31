using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Infrastructure.Configurations
{
    class Connection
    {
        public static string SqlConnectionString { get => @"Data Source=MuServer-PC;Initial Catalog=GeneralDB;Persist Security Info=True;User ID=sa;Password=!nformac@0"; }


        //Usar singleton aqui
    }
}
