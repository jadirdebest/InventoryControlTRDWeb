using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Infrastructure.Configurations
{
    class Connection
    {
        public static string SqlConnectionString { get => "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jadir\\source\\repos\\TesteEditoraLivros\\TesteEditoraLivros.Infrastructure\\DataBase\\DatabaseTeste.mdf;Integrated Security=True"; }


        //Usar singleton aqui
    }
}
