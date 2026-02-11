using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studiu_individual
{
    internal class Conecsiune
    {
        public SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Professional\Desktop\Colegiu\Programarea Vizuala\Studiu individual\MagazinAuto.mdf"";Integrated Security=True;Connect Timeout=30");
        //public SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\User\OneDrive\Desktop\Studiu individual (7)\Studiu individual\MagazinAuto.mdf"";Integrated Security=True;Connect Timeout=30");
    }
}
