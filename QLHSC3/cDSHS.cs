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
    class cDSHS
    {
        private string stt;
        private string hoten;
        private string lop;
        private string tbhk01;
        private string tbhh02;
        public string Stt { get => stt; set => stt = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Lop { get => lop; set => lop = value; }
        public string Tbhk01 { get => tbhk01; set => tbhk01 = value; }
        public string Tbhh02 { get => tbhh02; set => tbhh02 = value; }

        //Kết nối database
        public static DataTable getData()
        {
            SqlConnection conn = cKetNoi.getConn();
            string sqlSELECT = "SELECT * FROM DanhSachHocSinh";
            SqlCommand sqlcomd = new SqlCommand(sqlSELECT, conn);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DanhSachHocSinh", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
        private void TimKiem()
        {
            try
            {
                SqlConnection conn = cKetNoi.getConn();
                string sqlTimKiem = "SELECT * FROM DanhSachHocSinh WHERE Stt = @Stt";
                SqlCommand sqlcomd = new SqlCommand(sqlTimKiem, conn);
                sqlcomd.Parameters.AddWithValue("Stt", stt);
                sqlcomd.Parameters.AddWithValue("hotenHS", hoten);
                sqlcomd.Parameters.AddWithValue("lop", lop );
                sqlcomd.Parameters.AddWithValue("TBHK01", tbhk01);
                sqlcomd.Parameters.AddWithValue("TBHK02", tbhh02);
                conn.Open();
                sqlcomd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Không tìm thấy tên bạn yêu cầu", "Thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
