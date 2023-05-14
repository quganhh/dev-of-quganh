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
    public partial class frDangKy : Form
    {
        public frDangKy()
        {
            InitializeComponent();
        }

        private void frDangKy_Load(object sender, EventArgs e)
        {
            dgv.DataSource = cUser.getData();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count <= 0)
                return;
            int i = dgv.SelectedRows[0].Index;
            tb_user.Text = dgv.Rows[i].Cells[0].Value.ToString();
            tb_pass.Text = dgv.Rows[i].Cells[1].Value.ToString();
            cboRole.Text = dgv.Rows[i].Cells[2].Value.ToString();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            cUser dk = new cUser();
            //Thiết lập thông tin đối tượng cho p
            dk.Taikhoan = tb_user.Text;
            dk.Matkhau = tb_pass.Text;
            dk.LoaiTK = cboRole.Text;
            dk.Insert();
            dgv.DataSource = cUser.getData();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có thật sự muốn xóa hay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dl == DialogResult.No)
                return;
            cUser p = new cUser();

            //Thiết lập thông tin đối tượng cho p
            p.Taikhoan = tb_user.Text;

            p.Delete();
            dgv.DataSource = cUser.getData();
        }

        private void btn_lammoi_Click(object sender, EventArgs e)
        {
            foreach (var item in this.groupBox1.Controls)
                if (item is TextBox)
                    ((TextBox)item).Text = "";
            tb_user.Focus();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frDangNhap dn = new frDangNhap();
            dn.ShowDialog();
            this.Show();
        }

        private void frDangKy_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
