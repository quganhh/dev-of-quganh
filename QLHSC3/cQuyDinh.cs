using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QLHSC3
{
    class cQuyDinh
    {
        private string maqd;
        private string tenqd;
        private string giatri;

        static SqlConnection conn = cKetNoi.getConn();

        public string Maqd { get => maqd; set => maqd = value; }
        public string Tenqd { get => tenqd; set => tenqd = value; }
        public string Giatri { get => giatri; set => giatri = value; }
        public static DataTable getdata()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From QuyDinh", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
        public static int getValue(string maQD)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select giatri From QuyDinh Where maQD = '" + maQD + "'", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return int.Parse(tb.Rows[0][0].ToString());
        }
        public static float getValuefloat(string maQD)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select giatri From QuyDinh Where maQD = '" + maQD + "'", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return float.Parse(tb.Rows[0][0].ToString());
        }
    }
}
