using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLHSC3
{
    public partial class frBangDiemMonHoc : Form
    {
        public frBangDiemMonHoc()
        {
            InitializeComponent();
        }

        private void Load_TenLopHoc()
        {
            cb_Lop.DataSource = cLop.getdata_Lop();
            cb_Lop.DisplayMember = "Tenlop";
            cb_Lop.ValueMember = "Malop";
            cb_Lop.SelectedIndex = 0;
        }
        private void Load_TenMonHoc()
        {
            cb_monhoc.DataSource = cMonHoc.getData();
            cb_monhoc.DisplayMember = "Tenmonhoc";
            cb_monhoc.ValueMember = "Mamonhoc";
            cb_monhoc.SelectedIndex = 0;
        }

        private void Load_TenHocKy()
        {
            cb_HocKy.DataSource = cHocKi.getData();
            cb_HocKy.DisplayMember = "Tenhocky";
            cb_HocKy.ValueMember = "Mahocky";
            cb_HocKy.SelectedIndex = 0;
        }
        private void BangDiemMonHoc_Load(object sender, EventArgs e)
        {
            Load_TenLopHoc();
            Load_TenMonHoc();
            Load_TenHocKy();

            dgv.DataSource = cBDMH.getData();
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            cBDMH d = new cBDMH();

            //Thiết lập thông tin đối tượng cho p
            d.Mahs = tb_mahs.Text;
            d.Mamonhoc = new cMonHoc(cb_monhoc.SelectedValue.ToString(), cb_monhoc.SelectedText);
            d.Malop = new cLop(cb_Lop.SelectedValue.ToString(), cb_Lop.SelectedText);
            d.Mahk = new cHocKi(cb_HocKy.SelectedValue.ToString(), cb_HocKy.SelectedText);
            d.Diem15phut = tb_diem15p.Text;
            d.Diem1tiet = tbb_diem1tiet.Text;
            d.Diemcuoiki = tb_diemcuoiki.Text;
            d.Insert();
            foreach (var item in this.groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
            tb_mahs.Focus();
            dgv.DataSource = cBDMH.getData();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count <= 0)
                return;
            int i = dgv.SelectedRows[0].Index;
            tb_mahs.Text = dgv.Rows[i].Cells[0].Value.ToString();
            cb_monhoc.Text = dgv.Rows[i].Cells[1].Value.ToString();
            cb_Lop.Text = dgv.Rows[i].Cells[2].Value.ToString();
            cb_HocKy.Text = dgv.Rows[i].Cells[3].Value.ToString();
            tb_diem15p.Text = dgv.Rows[i].Cells[4].Value.ToString();
            tbb_diem1tiet.Text = dgv.Rows[i].Cells[5].Value.ToString();
            tb_diemcuoiki.Text = dgv.Rows[i].Cells[6].Value.ToString();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            foreach (var item in this.groupBox1.Controls)
                if (item is TextBox)
                    ((TextBox)item).Text = "";
            tb_mahs.Focus();

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            cBDMH tp = new cBDMH();

            //Thiết lập thông tin đối tượng cho p
            tp.Mahs = tb_mahs.Text;
            tp.Mamonhoc = new cMonHoc(cb_monhoc.SelectedValue.ToString(), cb_monhoc.SelectedText);
            tp.Malop = new cLop(cb_Lop.SelectedValue.ToString(), cb_Lop.SelectedText);
            tp.Mahk = new cHocKi(cb_HocKy.SelectedValue.ToString(), cb_HocKy.SelectedText);
            tp.Diem15phut = tb_diem15p.Text;
            tp.Diem1tiet = tbb_diem1tiet.Text;
            tp.Diemcuoiki = tb_diemcuoiki.Text;
            tp.Update();
            foreach (var item in this.groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
            tb_mahs.Focus();
            dgv.DataSource = cBDMH.getData();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có thật sự muốn xóa hay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dl == DialogResult.No)
                return;
            cBDMH p = new cBDMH();

            p.Mahs = tb_mahs.Text;

            p.Delete();
            foreach (var item in this.groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
            tb_mahs.Focus();
            dgv.DataSource = cBDMH.getData();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frHome h = new frHome();
            h.ShowDialog();
        }

        private void cb_Lop_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv.DataSource = cBDMH.getdataDiem_thong_qua_chon_lop(cb_Lop.SelectedValue.ToString());
        }
        private void cb_monhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv.DataSource = cBDMH.getdataDiem_thong_qua_chon_mon(cb_monhoc.SelectedValue.ToString());
        }
        private void cb_HocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv.DataSource = cBDMH.getdataDiem_thong_qua_chon_hocky(cb_HocKy.SelectedValue.ToString());
        }
    }
}
