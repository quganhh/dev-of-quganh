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
    class cBaoCaoTongKetHK
    {
        public static DataTable getData()
        {
            SqlConnection conn = cKetNoi.getConn();
            SqlDataAdapter da = new SqlDataAdapter("select LopHoc.tenlop, LopHoc.siso, COUNT(HoSoHocSinh.MaHocSinh) as N'Số Lượng Đạt', Format((1.0 * COUNT(HoSoHocSinh.MaHocSinh) / LopHoc.siso), 'P1') as N'Tỷ Lệ' from BDMH join LopHoc on LopHoc.malop = BDMH.MaLop join MonHoc on MonHoc.MaMonHoc = BDMh.MaMonHoc join HocKy on HocKy.MaHocKy = BDMH.MaHocKy join HoSoHocSinh on HoSoHocSinh.MaHocSinh = BDMH.Mahosinh Where(BDMH.Diem15phut + BDMH.Diem1tiet + BDMh.DiemcuoiHK) / 3 >= 5 and(BDMH.Diem15phut + BDMH.Diem1tiet * MonHoc.heso + BDMH.DiemcuoiHK) / 4 >= 5 group by LopHoc.tenlop, LopHoc.siso, MonHoc.tenmonhoc, HocKy.tenhocki", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
        public static DataTable getdata_TongKetHocKy_ThongQuaChonHocKy(string mahk)
        {
            SqlConnection conn = cKetNoi.getConn();
            SqlDataAdapter da = new SqlDataAdapter("select LopHoc.tenlop, LopHoc.siso, COUNT(HoSoHocSinh.MaHocSinh) as N'Số Lượng Đạt', Format((1.0 * COUNT(HoSoHocSinh.MaHocSinh) / LopHoc.siso), 'P1') as N'Tỷ Lệ' from BDMH join LopHoc on LopHoc.malop = BDMH.MaLop join MonHoc on MonHoc.MaMonHoc = BDMH.MaMonHoc join HocKy on HocKy.MaHocKy = BDMH.MaHocKy join HoSoHocSinh on HoSoHocSinh.MaHocSinh = BDMH.Mahosinh Where(BDMH.Diem15phut + BDMH.Diem1tiet + BDMH.DiemcuoiHK) / 3 >= 5 and(BDMH.Diem15phut + BDMH.Diem1Tiet * MonHoc.heso + BDMH.DiemcuoiHK) / 4 >= 5 and HocKy.MaHocKy = '" + mahk + "' group by LopHoc.tenlop, LopHoc.siso, MonHoc.tenmonhoc, HocKy.TenHocKy", conn);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }
    }
}
