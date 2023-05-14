using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLHSC3
{
    

    public partial class frDangNhap : Form
    {
        public frDangNhap()
        {
            InitializeComponent();
        }

        private void frDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void frDangNhap_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            
                cUser user = new cUser();
                user.Taikhoan = tb_user.Text;
                user.Matkhau = tb_pass.Text;
                user.LoaiTK = cboRole.Text;
                if (user.KiemTraNguoiDung() == false)
                {
                    MessageBox.Show("Rất Tiếc,Mời nhập lại một lần nữa!", "Thông báo !",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                   
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frHome h = new frHome();
                    h.ShowDialog();

                }        

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn hủy bỏ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void tb_pass_TextChanged(object sender, EventArgs e)
        {
            this.tb_pass.PasswordChar = '*';
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frDangKy dk = new frDangKy();
            dk.ShowDialog();
            
        }
    }
}
