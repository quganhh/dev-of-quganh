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
    
    public partial class frHome : Form
    {
        
        public frHome()
        {
            InitializeComponent();
        }



        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frHome_Load(object sender, EventArgs e)
        {

        }
       
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frDangKy dk = new frDangKy();
            dk.ShowDialog();
        }
        

        private void frHome_Load_1(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                frDangNhap dk = new frDangNhap();
                dk.ShowDialog();
            }
            
        }

        private void menuXuat_Click(object sender, EventArgs e)
        {

        }

        private void frHome_FormClosing(object sender, FormClosingEventArgs e)
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

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void HồSơHọcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frHoSohocSinh k = new frHoSohocSinh();
            k.ShowDialog();
        }

        private void DanhSáchHọcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frDSHS bm1 = new frDSHS();
            bm1.ShowDialog();
        }

        private void DanhSáchLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frDanhSachLop p = new frDanhSachLop();
            p.ShowDialog();
        }

        private void BảngĐiểmMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frBangDiemMonHoc tp = new frBangDiemMonHoc();
            tp.ShowDialog();
        }

        private void BáocáotổngkếtmônToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frBaocaotongketmon p = new frBaocaotongketmon();
            p.ShowDialog();
        }

        private void BáocáotổngkếthọckìToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frBaocaotongkethocki p = new frBaocaotongkethocki();
            p.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void trọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frlienhe p = new frlienhe();
            p.ShowDialog();
        }
    }
}
