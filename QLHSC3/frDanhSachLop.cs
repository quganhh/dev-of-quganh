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
    public partial class frDanhSachLop : Form
    {
        public frDanhSachLop()
        {
            InitializeComponent();
        }

        private void frDanhSachLop_Load(object sender, EventArgs e)
        {
            int qd_tuoi_min = cQuyDinh.getValue("QD01");
            int qd_tuoi_max = cQuyDinh.getValue("QD02");
            dtp_ngaysinh.MinDate = new DateTime(DateTime.Now.Year - qd_tuoi_max, 1, 1);
            dtp_ngaysinh.MaxDate = new DateTime(DateTime.Now.Year - qd_tuoi_min, 12, 31);

            cb_Lớp.DataSource = cLop.getdata_Lop();
            cb_Lớp.DisplayMember = "Tenlop";
            cb_Lớp.ValueMember = "Malop";
            cb_Lớp.SelectedIndex = 0;
            dgv.DataSource = cDSLop.getData();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            cDSLop ds = new cDSLop();
            ds.Mahs = tb_mahs.Text;            
            ds.Hoten = tb_hoten.Text;
            ds.Ngaysinh = dtp_ngaysinh.Value;
            ds.Gioitinh = cbo_gioitinh.Text;
            ds.Diachi = tb_diachi.Text;
            ds.Lop = new cLop(cb_Lớp.SelectedValue.ToString(), cb_Lớp.SelectedText);

            ds.Insert();
            foreach (var item in this.groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
            tb_mahs.Focus();
            dgv.DataSource = cDSLop.getData();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count <= 0)
                return;
            int i = dgv.SelectedRows[0].Index;
            tb_mahs.Text = dgv.Rows[i].Cells[0].Value.ToString();
            tb_hoten.Text = dgv.Rows[i].Cells[1].Value.ToString();
            cbo_gioitinh.Text = dgv.Rows[i].Cells[2].Value.ToString();
            dtp_ngaysinh.Value = DateTime.Parse(dgv.Rows[i].Cells[3].Value.ToString());
            tb_diachi.Text = dgv.Rows[i].Cells[4].Value.ToString();
            cb_Lớp.SelectedValue = dgv.Rows[i].Cells[5].Value.ToString();

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            cDSLop l = new cDSLop();
            l.Mahs = tb_mahs.Text;
            l.Hoten = tb_hoten.Text;
            l.Gioitinh = cbo_gioitinh.Text;
            l.Ngaysinh = dtp_ngaysinh.Value;
            l.Diachi = tb_diachi.Text;
            l.Lop = new cLop(cb_Lớp.SelectedValue.ToString(), cb_Lớp.SelectedText);

            l.Update();
            foreach (var item in this.groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
            tb_mahs.Focus();
            dgv.DataSource = cDSLop.getData();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có thật sự muốn xóa hay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dl == DialogResult.No)
                return;
            cDSLop ds = new cDSLop();

            //Thiết lập thông tin đối tượng cho p
            ds.Mahs = tb_mahs.Text;

            ds.Delete();
            foreach (var item in this.groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
            tb_mahs.Focus();
            dgv.DataSource = cDSLop.getData();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            foreach (var item in this.groupBox1.Controls)
                if (item is TextBox)
                    ((TextBox)item).Text = "";
            cb_Lớp.Focus();
        }

        private void frDanhSachPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn Có Muốn Thoát Chương Trình Hay Không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                Application.ExitThread();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frHome h = new frHome();
            h.ShowDialog();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cb_Lớp_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv.DataSource = cLop.getdata_dsLop(cb_Lớp.Text.ToString());
            DataTable tbl = (DataTable)cb_Lớp.DataSource;
            tb_siso.Text = tbl.Rows[cb_Lớp.SelectedIndex][2].ToString();
        }
    }
}
