using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLHSC3
{
    class cKetNoi
    {
        public static SqlConnection getConn()
        {
            SqlConnection conn;
            string chuoiketnoi = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            conn = new SqlConnection(chuoiketnoi);
            return conn;
        }
    }
}
