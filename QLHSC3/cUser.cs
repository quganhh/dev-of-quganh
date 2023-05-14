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
    class cUser
    {
        private string taikhoan;
        private string matkhau;
        private string loaiTK;

        public string Taikhoan { get => taikhoan; set => taikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public string LoaiTK { get => loaiTK; set => loaiTK = value; }

        static SqlConnection conn = cKetNoi.getConn();
        public bool KiemTraNguoiDung()
        {
            SqlCommand sqlcomd = new SqlCommand();
            sqlcomd.CommandText = "SELECT * FROM DMTK WHERE taikhoan=@taikhoan and matkhau=@matkhau and loaitk=@loaiTK ";
            sqlcomd.Parameters.AddWithValue("@taikhoan", taikhoan);
            sqlcomd.Parameters.AddWithValue("@matkhau", matkhau);
            sqlcomd.Parameters.AddWithValue("@loaiTK", loaiTK);
            sqlcomd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(sqlcomd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            if (tb.Rows.Count > 0)
                return true;
            return false;
        }

        public static DataTable getData()
        {
            string sqlSELECT = "SELECT * FROM DMTK";
            SqlCommand sqlcomd = new SqlCommand(sqlSELECT, conn);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DMTK", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
        public void Insert()
        {
            try
            {
                string sqlINSERT = "INSERT INTO DMTK VALUES(@taikhoan, @matkhau, @loaitk)";
                SqlCommand sqlcomd = new SqlCommand(sqlINSERT, conn);
                sqlcomd.Parameters.AddWithValue("taikhoan", taikhoan);
                sqlcomd.Parameters.AddWithValue("matkhau", matkhau);
                sqlcomd.Parameters.AddWithValue("loaitk", loaiTK);
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
                string sqlEdit = "UPDATE DMTK SET matkhau = @matkhau and loaitk = @loaitk WHERE taikhoan = @taikhoan";
                SqlCommand sqlcomd = new SqlCommand(sqlEdit, conn);
                sqlcomd.Parameters.AddWithValue("taikhoan", taikhoan);
                sqlcomd.Parameters.AddWithValue("matkhau", matkhau);
                sqlcomd.Parameters.AddWithValue("loaitk", loaiTK);
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
                string sqlDELETE = "DELETE FROM DMTK WHERE taikhoan=@taikhoan ";
                SqlCommand sqlcomd = new SqlCommand(sqlDELETE, conn);
                sqlcomd.Parameters.AddWithValue("taikhoan", taikhoan);
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
