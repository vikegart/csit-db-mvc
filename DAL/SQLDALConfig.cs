using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SQLDALConfig
    {
        static string cs = "Data Source=EPRUSARW0980\\SQLEXPRESS;Initial Catalog=AwardsDB;Integrated Security=True";
        //public static string ConnectionString { get; } = ConfigurationManager.ConnectionStrings["DataAccess"].ConnectionString;
        public static string ConnectionString { get; } = cs;

    }
}
