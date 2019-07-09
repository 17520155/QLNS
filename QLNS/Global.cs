using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace QLNS
{
    public class Global
    {
        private static string connectionStr = ConfigurationManager.ConnectionStrings["MyconnectionString"].ConnectionString;

        public static string ConnectionStr { get => connectionStr; set => connectionStr = value; }
    }
}