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
    public partial class frBaocaotongketmon : Form
    {
        public frBaocaotongketmon()
        {
            InitializeComponent();
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
            cb_hocky.DataSource = cHocKi.getData();
            cb_hocky.DisplayMember = "Tenhocky";
            cb_hocky.ValueMember = "Mahocky";
            cb_hocky.SelectedIndex = 0;
        }
        private void BaoCaoTongKetMon_Load(object sender, EventArgs e)
        {
            Load_TenMonHoc();
            Load_TenHocKy();

            float qd_diemchuandatmon = cQuyDinh.getValuefloat("QD06");
            if (dgv.Rows.Count == qd_diemchuandatmon)
            {
                dgv.DataSource = cBaoCaoTongKetMon.getData();
            }
            dgv.DataSource = cBaoCaoTongKetMon.getData();
        }

        private void frBm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frHome h = new frHome();
            h.ShowDialog();
        }

        private void frBm2_FormClosing_1(object sender, FormClosingEventArgs e)
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
        private void cb_monhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv.DataSource = cBaoCaoTongKetMon.getdata_TongKetMon_ThongQuaChonMonHoc(cb_monhoc.SelectedValue.ToString());
        }

        private void cb_hocky_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv.DataSource = cBaoCaoTongKetMon.getdata_TongKetMon_ThongQuaChonHocKy(cb_hocky.SelectedValue.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string dir = folder.SelectedPath;

                // creating Excel Application  
                _Application app = new Microsoft.Office.Interop.Excel.Application();

                // creating new WorkBook within Excel application  
                _Workbook workbook = app.Workbooks.Add(Type.Missing);

                // creating new Worksheet in workbook  
                _Worksheet worksheet = null;

                // see the excel sheet behind the program  
                //app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;

                // changing the name of active sheet  
                worksheet.Name = "Exported from gridview";

                // storing header part in Excel  
                for (int i = 1; i < dgv.Columns.Count + 1; i++)
                    worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;

                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // save the application  
                workbook.SaveAs(dir + "\\output.xlsx");
                app.Quit();
            }
        }

    }
}
