﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class SQLDALConfig
    {
        public static string ConnectionString { get; } = ConfigurationManager.ConnectionStrings["DataAccess"].ConnectionString;
    }
}
