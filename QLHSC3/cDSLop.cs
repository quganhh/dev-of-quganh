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
    class cDSLop
    {
        private string mahs;
        private string hoten;
        private string gioitinh;
        private DateTime ngaysinh;
        private string diachi;
        private string siso;
        private cLop lop;

        static SqlConnection conn = cKetNoi.getConn();

        public string Mahs { get => mahs; set => mahs = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        internal cLop Lop { get => lop; set => lop = value; }
        public string Siso { get => siso; set => siso = value; }

        //Kết nối database
        public static DataTable getData()
        {
            string sqlSELECT = "SELECT DSLophoc.Mahosinh, DSLophoc.HovaTen, DSLophoc.gioitinh, DSLophoc.ngaysinh, DSLophoc.DiaChi, LopHoc.malop, Lophoc.siso FROM DSLophoc join LopHoc on LopHoc.malop = DSLophoc.Malop";
            SqlCommand sqlcomd = new SqlCommand(sqlSELECT, conn);
            SqlDataAdapter da = new SqlDataAdapter("SELECT DSLophoc.Mahosinh, DSLophoc.HovaTen, DSLophoc.gioitinh, DSLophoc.ngaysinh, DSLophoc.DiaChi, LopHoc.malop, Lophoc.siso FROM DSLophoc join LopHoc on LopHoc.malop = DSLophoc.Malop", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }

        public void Insert()
        {
            try
            {
                string sqlINSERT = "INSERT INTO DSLophoc VALUES(@Mahosinh, @HovaTen, @gioitinh, @ngaysinh, @DiaChi, @Malop)";
                SqlCommand sqlcomd = new SqlCommand(sqlINSERT,conn);
                sqlcomd.Parameters.AddWithValue("Mahosinh", mahs);
                sqlcomd.Parameters.AddWithValue("HovaTen", hoten);
                sqlcomd.Parameters.AddWithValue("gioitinh", gioitinh);
                sqlcomd.Parameters.AddWithValue("ngaysinh", ngaysinh);
                sqlcomd.Parameters.AddWithValue("DiaChi ", diachi);
                sqlcomd.Parameters.AddWithValue("Malop", lop.Malop);
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
                string sqlEdit = "UPDATE DSLophoc SET HovaTen = @HovaTen, gioitinh = @gioitinh, ngaysinh = @ngaysinh, DiaChi = @DiaChi, Malop = @Malop WHERE Mahosinh = @Mahosinh";
                SqlCommand sqlcomd = new SqlCommand(sqlEdit, conn);
                sqlcomd.Parameters.AddWithValue("Mahosinh", mahs);
                sqlcomd.Parameters.AddWithValue("HovaTen", hoten);
                sqlcomd.Parameters.AddWithValue("gioitinh", gioitinh);
                sqlcomd.Parameters.AddWithValue("ngaysinh", ngaysinh);
                sqlcomd.Parameters.AddWithValue("DiaChi ", diachi);
                sqlcomd.Parameters.AddWithValue("Malop", lop.Malop);
                conn.Open();
                sqlcomd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {

                MessageBox.Show("Lỗi", "Thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Nút xóa
        public void Delete()
        {
            try
            {
                string sqlDELETE = "DELETE FROM DSLophoc WHERE Mahosinh = @Mahosinh ";
                SqlCommand sqlcomd = new SqlCommand(sqlDELETE,conn);
                sqlcomd.Parameters.AddWithValue("Mahosinh", mahs);
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
