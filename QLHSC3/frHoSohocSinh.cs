using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace QLHSC3
{
    public partial class frHoSohocSinh : Form
    {
        public frHoSohocSinh()
        {
            InitializeComponent();
        }
        private void HồSơHọcSinh_Load(object sender, EventArgs e)
        {
            int qd_tuoi_min = cQuyDinh.getValue("QD01");
            int qd_tuoi_max = cQuyDinh.getValue("QD02");
            dtp_ngaysinh.MinDate = new DateTime(DateTime.Now.Year - qd_tuoi_max, 1, 1);
            dtp_ngaysinh.MaxDate = new DateTime(DateTime.Now.Year - qd_tuoi_min, 12, 31);

            dgv.DataSource = cHoSo.getData();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            cHoSo p = new cHoSo();

            //Thiết lập thông tin đối tượng cho p
            p.Hoten = tb_hoten.Text;
            p.Ngaysinh = dtp_ngaysinh.Value;
            p.Gioitinh = cb_gioitinh.Text;
            p.Diachi = tb_email.Text;
            p.Email = tb_diachi.Text;
            p.Mahs = tb_mahs.Text;


            p.Insert();
            dgv.DataSource = cHoSo.getData();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có thật sự muốn xóa hay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dl == DialogResult.No)
                return;
            cHoSo p = new cHoSo();

            //Thiết lập thông tin đối tượng cho p
            p.Hoten = tb_hoten.Text;

            p.Delete();
            dgv.DataSource = cHoSo.getData();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            foreach (var item in this.groupBox1.Controls)
                if (item is System.Windows.Forms.TextBox)
                    ((System.Windows.Forms.TextBox)item).Text = "";
            tb_hoten.Focus();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            cHoSo p = new cHoSo();

            //Thiết lập thông tin đối tượng cho p
            p.Hoten = tb_hoten.Text;
            p.Ngaysinh = dtp_ngaysinh.Value;
            p.Gioitinh = cb_gioitinh.Text;
            p.Diachi = tb_diachi.Text;
            p.Email = tb_email.Text;
            p.Mahs = tb_mahs.Text;


            p.Update();
            dgv.DataSource = cHoSo.getData();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count <= 0)
                return;
            int i = dgv.SelectedRows[0].Index;
            tb_mahs.Text = dgv.Rows[i].Cells[0].Value.ToString();
            tb_hoten.Text = dgv.Rows[i].Cells[1].Value.ToString();
            dtp_ngaysinh.Value = DateTime.Parse (dgv.Rows[i].Cells[2].Value.ToString());
            cb_gioitinh.Text = dgv.Rows[i].Cells[3].Value.ToString();
            tb_email.Text = dgv.Rows[i].Cells[4].Value.ToString();
            tb_diachi.Text = dgv.Rows[i].Cells[5].Value.ToString();

        }

        private void HồSơHọcSinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn Có Muốn Thoát Chương Trình Hay Không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                System.Windows.Forms.Application.ExitThread();
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frHome h = new frHome();
            h.ShowDialog();
        }


        private void btn_inexcel_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog folder = new FolderBrowserDialog();
            //if (folder.ShowDialog() == DialogResult.OK)
            //{
            //    string dir = folder.SelectedPath;

            //    // creating Excel Application  
            //    _Application app = new Microsoft.Office.Interop.Excel.Application();

            //    // creating new WorkBook within Excel application  
            //    _Workbook workbook = app.Workbooks.Add(Type.Missing);

            //    // creating new Worksheet in workbook  
            //    _Worksheet worksheet = null;

            //    // see the excel sheet behind the program  
            //    //app.Visible = true;
            //    // get the reference of first sheet. By default its name is Sheet1.  
            //    // store its reference to worksheet  
            //    worksheet = workbook.Sheets["Sheet1"];
            //    worksheet = workbook.ActiveSheet;

            //    // changing the name of active sheet  
            //    worksheet.Name = "Exported from gridview";

            //    // storing header part in Excel  
            //    for (int i = 1; i < dgv.Columns.Count + 1; i++)
            //        worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;

            //    // storing Each row and column value to excel sheet  
            //    for (int i = 0; i < dgv.Rows.Count - 1; i++)
            //    {
            //        for (int j = 0; j < dgv.Columns.Count; j++)
            //        {
            //            worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
            //        }
            //    }
            //    // save the application  
            //    workbook.SaveAs(dir + "\\output.xlsx");
            //    app.Quit();
            //}
        }
    }
}
