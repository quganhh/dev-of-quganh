using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLHSC3
{
    class cHocKi
    {
        private string mahocky;
        private string tenhocky;
        private int heSo;

        static SqlConnection conn = cKetNoi.getConn();

        public string Mahocky { get => mahocky; set => mahocky = value; }
        public string Tenhocky { get => tenhocky; set => tenhocky = value; }
        public int HeSo { get => heSo; set => heSo = value; }

        public cHocKi(string m, string t)
        {
            mahocky = m;
            tenhocky = t;
        }

        public static DataTable getData()
        {
            string sqlSELECT = "SELECT * FROM HocKy";
            SqlCommand sqlcomd = new SqlCommand(sqlSELECT, conn);
            SqlDataAdapter da = new SqlDataAdapter("Select * From HocKy", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }

    }
}
