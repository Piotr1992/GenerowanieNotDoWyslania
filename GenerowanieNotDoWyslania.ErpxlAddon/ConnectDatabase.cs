using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hydra;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime;
using GenerowanieNotDoWyslania.ErpxlAddon.Model;

namespace GenerowanieNotDoWyslania.ErpxlAddon
{
    class ConnectDatabase
    {
        public SqlConnection connecting()
        {           
            SqlConnection conn = new SqlConnection("Data Source=" + Runtime.Config.Serwer + ";Initial Catalog=" + Runtime.Config.Baza + ";User Id=Hydra;Password=Hydra;");

            return conn;
        }        
    }
}
