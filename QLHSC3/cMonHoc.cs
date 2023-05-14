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
    class cMonHoc
    {
        private string mamon;
        private string tenmon;
        private string soTiet;
        private string heSo;

        public string Mamon { get => mamon; set => mamon = value; }
        public string Tenmon { get => tenmon; set => tenmon = value; }
        public string SoTiet { get => soTiet; set => soTiet = value; }
        public string HeSo { get => heSo; set => heSo = value; }


        static SqlConnection conn = cKetNoi.getConn();
        public cMonHoc(string m, string t)
        {
            mamon = m;
            tenmon = t;
        }
        public static DataTable getData()
        {
            string sqlSELECT = "SELECT * FROM MonHoc";
            SqlCommand sqlcomd = new SqlCommand(sqlSELECT, conn);
            SqlDataAdapter da = new SqlDataAdapter("Select * From MonHoc", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
        public void Insert()
        {
            try
            {
                string sqlINSERT = "INSERT INTO MonHoc VALUES((@MaMonHoc, @tenmonhoc, @sotiet, @heso)";
                SqlCommand sqlcomd = new SqlCommand(sqlINSERT, conn);
                sqlcomd.Parameters.AddWithValue("MaMonHoc", mamon);
                sqlcomd.Parameters.AddWithValue("tenmon", tenmon);
                sqlcomd.Parameters.AddWithValue("sotiet", soTiet);
                sqlcomd.Parameters.AddWithValue("heso", heSo);
                conn.Open();
                sqlcomd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Update()
        {
            try
            {
                string sqlEdit = "UPDATE MonHoc SET tenmonhoc = @tenmonhoc, sotiet = @sotiet, heso = @heso WHERE MaMonHoc =@MaMonHoc";
                SqlCommand sqlcomd = new SqlCommand(sqlEdit, conn);
                sqlcomd.Parameters.AddWithValue("MaMonHoc", mamon);
                sqlcomd.Parameters.AddWithValue("tenmon", tenmon);
                sqlcomd.Parameters.AddWithValue("sotiet", soTiet);
                sqlcomd.Parameters.AddWithValue("heso", heSo);
                conn.Open();
                sqlcomd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {

                MessageBox.Show("Lỗi", "Thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Delete()
        {
            try
            {
                string sqlDELETE = "DELETE FROM MonHoc WHERE MaMonHoc = @MaMonHoc ";
                SqlCommand sqlcomd = new SqlCommand(sqlDELETE, conn);
                sqlcomd.Parameters.AddWithValue("MaMonHoc", mamon);

                conn.Open();
                sqlcomd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
