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
    class cBDMH
    {
        private string mahs;
        private cHocKi mahk;
        private cMonHoc mamonhoc;
        private cLop malop;
        private string diem15phut;
        private string diem1tiet;
        private string diemcuoiki;
        

        

        static SqlConnection conn = cKetNoi.getConn();

        public string Mahs { get => mahs; set => mahs = value; }
        internal cHocKi Mahk { get => mahk; set => mahk = value; }
        internal cMonHoc Mamonhoc { get => mamonhoc; set => mamonhoc = value; }
        internal cLop Malop { get => malop; set => malop = value; }
        public string Diem15phut { get => diem15phut; set => diem15phut = value; }
        public string Diem1tiet { get => diem1tiet; set => diem1tiet = value; }
        public string Diemcuoiki { get => diemcuoiki; set => diemcuoiki = value; }

        public void Insert()
        {
            try
            {
                string sqlINSERT = "INSERT INTO BDMH VALUES(@Mahosinh, @MaMonHoc, @MaHocKy, @MaLop, @Diem15phut, @Diem1tiet, @DiemcuoiHK)";
                SqlCommand sqlcomd = new SqlCommand(sqlINSERT, conn);
                sqlcomd.Parameters.AddWithValue("Mahosinh", mahs);
                sqlcomd.Parameters.AddWithValue("MaMonHoc", mamonhoc);
                sqlcomd.Parameters.AddWithValue("MaHocKy", mahk);
                sqlcomd.Parameters.AddWithValue("MaLop", malop);
                sqlcomd.Parameters.AddWithValue("Diem15phut", diem15phut);
                sqlcomd.Parameters.AddWithValue("Diem1tiet", diem1tiet);
                sqlcomd.Parameters.AddWithValue("DiemcuoiHK", diemcuoiki);
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
                string sqlEdit = "UPDATE BDMH SET MaMonHoc = @MaMonHoc, MaHocKy = @MaHocKy, MaLop = @MaLop, Diem15phut = @Diem15phut, Diem1tiet = @Diem1tiet, DiemcuoiHK = @DiemcuoiHK WHERE Mahosinh =@Mahosinh";
                SqlCommand sqlcomd = new SqlCommand(sqlEdit, conn);
                sqlcomd.Parameters.AddWithValue("Mahosinh", mahs);
                sqlcomd.Parameters.AddWithValue("MaMonHoc", mamonhoc);
                sqlcomd.Parameters.AddWithValue("MaHocKy", mahk);
                sqlcomd.Parameters.AddWithValue("MaLop", malop);
                sqlcomd.Parameters.AddWithValue("Diem15phut", diem15phut);
                sqlcomd.Parameters.AddWithValue("Diem1tiet", diem1tiet);
                sqlcomd.Parameters.AddWithValue("DiemcuoiHK", diemcuoiki);
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
                string sqlDELETE = "DELETE FROM BDMH WHERE Mahosinh = @Mahosinh ";
                SqlCommand sqlcomd = new SqlCommand();
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
        public static DataTable getData()
        {
            string sqlSELECT = "SELECT BDMH.Mahosinh, MonHoc.tenmonhoc, LopHoc.tenlop, HocKy.tenhocki, BDMH.Diem15phut, BDMH.Diem1tiet, BDMH.DiemcuoiHK FROM BDMH JOIN MonHoc ON MonHoc.MaMonHoc = BDMH.MaMonHoc JOIN LopHoc ON LopHoc.malop = BDMH.MaLop JOIN HocKy ON HocKy.MaHocKy = BDMH.MaHocKy";
            SqlCommand sqlcomd = new SqlCommand(sqlSELECT, conn);
            SqlDataAdapter da = new SqlDataAdapter("SELECT BDMH.Mahosinh, MonHoc.tenmonhoc, LopHoc.tenlop, HocKy.tenhocki, BDMH.Diem15phut, BDMH.Diem1tiet, BDMH.DiemcuoiHK FROM BDMH JOIN MonHoc ON MonHoc.MaMonHoc = BDMH.MaMonHoc JOIN LopHoc ON LopHoc.malop = BDMH.MaLop JOIN HocKy ON HocKy.MaHocKy = BDMH.MaHocKy", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
        public static DataTable getdataDiem_thong_qua_chon_lop(string malop)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT BDMH.Mahosinh, MonHoc.tenmonhoc, LopHoc.tenlop, HocKy.tenhocki, BDMH.Diem15phut, BDMH.Diem1tiet, BDMH.DiemcuoiHK FROM BDMH JOIN MonHoc ON MonHoc.MaMonHoc = BDMH.MaMonHoc JOIN LopHoc ON LopHoc.malop = BDMH.MaLop JOIN HocKy ON HocKy.MaHocKy = BDMH.MaHocKy WHERE BDMH.MaLop = '" + malop + "'", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }

        public static DataTable getdataDiem_thong_qua_chon_mon(string mamon)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT BDMH.Mahosinh, MonHoc.tenmonhoc, LopHoc.tenlop, HocKy.tenhocki, BDMH.Diem15phut, BDMH.Diem1tiet, BDMH.DiemcuoiHK FROM BDMH JOIN MonHoc ON MonHoc.MaMonHoc = BDMH.MaMonHoc JOIN LopHoc ON LopHoc.malop = BDMH.MaLop JOIN HocKy ON HocKy.MaHocKy = BDMH.MaHocKy WHERE BDMH.MaMonHoc = '" + mamon + "'", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }

        public static DataTable getdataDiem_thong_qua_chon_hocky(string mahk)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT BDMH.Mahosinh, MonHoc.tenmonhoc, LopHoc.tenlop, HocKy.tenhocki, BDMH.Diem15phut, BDMH.Diem1tiet, BDMH.DiemcuoiHK FROM BDMH JOIN MonHoc ON MonHoc.MaMonHoc = BDMH.MaMonHoc JOIN LopHoc ON LopHoc.malop = BDMH.MaLop JOIN HocKy ON HocKy.MaHocKy = BDMH.MaHocKy WHERE BDMH.MaHocKy = '" + mahk + "'", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
    }
}
