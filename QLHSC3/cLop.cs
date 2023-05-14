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
    class cLop
    {
        private string malop;
        private string tenlop;
        private string siso;
        private string makhoilop;

        public string Malop { get => malop; set => malop = value; }
        public string Tenlop { get => tenlop; set => tenlop = value; }
        public string Siso { get => siso; set => siso = value; }
        public string Makhoilop { get => makhoilop; set => makhoilop = value; }

        static SqlConnection conn = cKetNoi.getConn();

        public cLop(string ma, string ten)
        {
            malop = ma;
            tenlop = ten;
        }
        public void ThemThongTin()
        {
            try
            {
                SqlCommand sqlcomd = new SqlCommand();
                sqlcomd.Connection = conn;
                sqlcomd.CommandText = "INSERT INTO LopHoc VALUES(@malop, @tenlop, @siso, @makhoilop)";
                sqlcomd.Parameters.AddWithValue("@malop", malop);
                sqlcomd.Parameters.AddWithValue("@tenlop", tenlop);
                sqlcomd.Parameters.AddWithValue("@siso", siso);
                sqlcomd.Parameters.AddWithValue("@makhoilop", makhoilop);

                conn.Open();
                sqlcomd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thông tin không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SuaThongTin()
        {
            try
            {
                SqlCommand sqlcomd = new SqlCommand();
                sqlcomd.Connection = conn;
                sqlcomd.CommandText = "UPDATE LopHoc SET tenlop = @tenlop, siso = @siso, makhoilop = @makhoilop WHERE malop = @malop";
                sqlcomd.Parameters.AddWithValue("@malop", malop);
                sqlcomd.Parameters.AddWithValue("@tenlop", tenlop);
                sqlcomd.Parameters.AddWithValue("@siso", siso);
                sqlcomd.Parameters.AddWithValue("@makhoilop", makhoilop);
                conn.Open();
                sqlcomd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa thông tin không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void XoaThongTin()
        {
            try
            {
                DialogResult xoa = MessageBox.Show("Bạn có muốn xóa thông tin này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (xoa == DialogResult.Yes)
                {
                    SqlCommand sqlcomd = new SqlCommand();
                    sqlcomd.Connection = conn;
                    sqlcomd.CommandText = "DELETE FROM LopHoc WHERE malop = @malop";
                    sqlcomd.Parameters.AddWithValue("@malop", malop);

                    conn.Open();
                    sqlcomd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thông tin không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static DataTable getdata_Lop()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From LopHoc", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
        public static DataTable getdata_dsLop(string malop)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT DSLophoc.Mahosinh, DSLophoc.HovaTen, LopHoc.tenlop, DSLophoc.gioitinh, DSLophoc.ngaysinh, DSLophoc.DiaChi FROM DSLophoc join LopHoc on LopHoc.malop = DSLophoc.Malop WHERE LopHoc.malop = '" + malop + "'", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
    } 
}
