﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS
{
    static public class Global
    {
        static string connectionStr = @"Data Source=DESKTOP-2SM9U8H;Initial Catalog=QLNS;Integrated Security=True";

        public static string ConnectionStr { get => connectionStr;}
    }
}