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
    class cHoSo
    {
        private string mahs;
        private string hoten;
        private DateTime ngaysinh;
        private string gioitinh;
        private string diachi;
        private string email;
        
        static SqlConnection conn = cKetNoi.getConn();

        public string Hoten { get => hoten; set => hoten = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Email { get => email; set => email = value; }
        public string Mahs { get => mahs; set => mahs = value; }

        public void Insert()
        {
            try
            {

                string sqlINSERT = "INSERT INTO HoSoHocSinh VALUES(@MaHocSinh, @hotenHS, @ngaysinhHS, @gioitinhHS, @diachiHS, @email)";
                SqlCommand sqlcomd = new SqlCommand(sqlINSERT, conn);
                sqlcomd.Parameters.AddWithValue("MaHocSinh", mahs);
                sqlcomd.Parameters.AddWithValue("hotenHS", hoten);
                sqlcomd.Parameters.AddWithValue("ngaysinhHS",ngaysinh);
                sqlcomd.Parameters.AddWithValue("gioitinhHS", gioitinh);
                sqlcomd.Parameters.AddWithValue("diachiHS", Diachi);
                sqlcomd.Parameters.AddWithValue("email", email);
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
                string sqlEdit = "UPDATE HoSoHocSinh SET hotenHS = @hotenHS, ngaysinhHS = @ngaysinhHS, gioitinhHS = @gioitinhHS, diachiHS = @diachiHS, email = @email WHERE MaHocSinh = @MaHocSinh";
                SqlCommand sqlcomd = new SqlCommand(sqlEdit,conn);
                sqlcomd.Parameters.AddWithValue("MaHocSinh", mahs);
                sqlcomd.Parameters.AddWithValue("hotenHS", hoten);
                sqlcomd.Parameters.AddWithValue("ngaysinhHS", ngaysinh);
                sqlcomd.Parameters.AddWithValue("gioitinhHS", gioitinh);
                sqlcomd.Parameters.AddWithValue("diachiHS", Diachi);
                sqlcomd.Parameters.AddWithValue("email", email);
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
                string sqlDELETE = "DELETE FROM HoSoHocSinh WHERE MaHocSinh = @MaHocSinh ";
                SqlCommand sqlcomd = new SqlCommand(sqlDELETE, conn);
                sqlcomd.Parameters.AddWithValue("MaHocSinh", mahs);
                conn.Open();
                sqlcomd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static DataTable getData()
        {
            string sqlSELECT = "SELECT * FROM HoSoHocSinh";
            SqlCommand sqlcomd = new SqlCommand(sqlSELECT, conn);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HoSoHocSinh", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
        public static DataTable laydulieu_dshs()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT HoSoHocSinh.MaHocSinh, HoSoHocSinh.hotenHS, MonHoc.tenmonhoc, LopHoc.tenlop, SUM(BDMH.Diem15phut + BDMH.Diem1tiet + BDMH.DiemcuoiHK) / 3 as 'TBHK01', SUM(BDMH.Diem15phut + BDMH.Diem1tiet * MonHoc.heso + BDMH.DiemcuoiHK) / 4 as 'TBHK02' FROM BDMH join HoSoHocSinh on HoSoHocSinh.MaHocSinh = BDMH.Mahosinh join LopHoc on LopHoc.malop = BDMH.MaLop join MonHoc on BDMH.MaMonHoc = MonHoc.MaMonHoc GROUP BY HoSoHocSinh.MaHocSinh, HoSoHocSinh.hotenHS, LopHoc.tenlop, MonHoc.tenmonhoc", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
        public static DataTable TimMaHocSinh_DsHocSinh(string mahs)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT HoSoHocSinh.MaHocSinh, HoSoHocSinh.hotenHS, MonHoc.tenmonhoc, LopHoc.tenlop, SUM(BDMH.Diem15phut + BDMH.Diem1tiet + BDMH.DiemcuoiHK) / 3 as 'TBHK01', SUM(BDMH.Diem15phut + BDMH.Diem1tiet * MonHoc.heso + BDMH.DiemcuoiHK) / 4 as 'TBHK02' FROM BDMH join HoSoHocSinh on HoSoHocSinh.MaHocSinh = BDMH.Mahosinh join LopHoc on LopHoc.malop = BDMH.MaLop join MonHoc on BDMH.MaMonHoc = MonHoc.MaMonHoc WHERE HoSoHocSinh.MaHocSinh = '" + mahs + "' GROUP BY HoSoHocSinh.MaHocSinh, HoSoHocSinh.hotenHS, LopHoc.tenlop, MonHoc.tenmonhoc", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
        public static DataTable TimTenHocSinh_DsHocSinh(string hovaten)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT HoSoHocSinh.MaHocSinh, HoSoHocSinh.hotenHS, MonHoc.tenmonhoc, LopHoc.tenlop, SUM(BDMH.Diem15phut + BDMH.Diem1tiet + BDMH.DiemcuoiHK) / 3 as 'TBHK01', SUM(BDMH.Diem15phut + BDMH.Diem1tiet * MonHoc.heso + BDMH.DiemcuoiHK) / 4 as 'TBHK02' FROM BDMH join HoSoHocSinh on HoSoHocSinh.MaHocSinh = BDMH.Mahosinh join LopHoc on LopHoc.malop = BDMH.MaLop join MonHoc on BDMH.MaMonHoc = MonHoc.MaMonHoc WHERE HoSoHocSinh.hotenHS = N'" + hovaten + "' GROUP BY HoSoHocSinh.MaHocSinh, HoSoHocSinh.hotenHS, LopHoc.tenlop, MonHoc.tenmonhoc", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
        public static DataTable XuatDsHocSinh_KhiNhanLamLai()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT HoSoHocSinh.MaHocSinh, HoSoHocSinh.hotenHS, MonHoc.tenmonhoc, LopHoc.tenlop, SUM(BDMH.Diem15phut + BDMH.Diem1tiet + BDMH.DiemcuoiHK) / 3 as 'TBHK01', SUM(BDMH.Diem15phut + BDMH.Diem1tiet * MonHoc.heso + BDMH.DiemcuoiHK) / 4 as 'TBHK02' FROM BDMH join HoSoHocSinh on HoSoHocSinh.MaHocSinh = BDMH.Mahosinh join LopHoc on LopHoc.malop = BDMH.MaLop join MonHoc on BDMH.MaMonHoc = MonHoc.MaMonHoc GROUP BY HoSoHocSinh.MaHocSinh, HoSoHocSinh.MaHocSinh, HoSoHocSinh.hotenHS, LopHoc.tenlop, MonHoc.tenmonhoc", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
    }
}
