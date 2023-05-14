
namespace QLHSC3
{
    partial class frDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frDangNhap));
            this.tb_pass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_user = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSignup = new FontAwesome.Sharp.IconButton();
            this.btn_exit = new FontAwesome.Sharp.IconButton();
            this.btn_login = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tb_pass
            // 
            this.tb_pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_pass.Location = new System.Drawing.Point(318, 120);
            this.tb_pass.Margin = new System.Windows.Forms.Padding(2);
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.Size = new System.Drawing.Size(154, 24);
            this.tb_pass.TabIndex = 19;
            this.tb_pass.TextChanged += new System.EventHandler(this.tb_pass_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(183, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "PASSWORD:";
            // 
            // tb_user
            // 
            this.tb_user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_user.Location = new System.Drawing.Point(318, 83);
            this.tb_user.Margin = new System.Windows.Forms.Padding(2);
            this.tb_user.Name = "tb_user";
            this.tb_user.Size = new System.Drawing.Size(154, 24);
            this.tb_user.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(183, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "USER:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(250, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 37);
            this.label4.TabIndex = 19;
            this.label4.Text = "login";
            // 
            // btnSignup
            // 
            this.btnSignup.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSignup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSignup.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnSignup.IconColor = System.Drawing.Color.Black;
            this.btnSignup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSignup.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSignup.Location = new System.Drawing.Point(355, 266);
            this.btnSignup.Margin = new System.Windows.Forms.Padding(2);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(205, 37);
            this.btnSignup.TabIndex = 27;
            this.btnSignup.Text = "SIGN UP";
            this.btnSignup.UseVisualStyleBackColor = false;
            this.btnSignup.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_exit.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
            this.btn_exit.IconColor = System.Drawing.Color.Black;
            this.btn_exit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_exit.Location = new System.Drawing.Point(355, 317);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(205, 37);
            this.btn_exit.TabIndex = 26;
            this.btn_exit.Text = "EXIT";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_login.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.btn_login.IconColor = System.Drawing.Color.Black;
            this.btn_login.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_login.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_login.Location = new System.Drawing.Point(355, 214);
            this.btn_login.Margin = new System.Windows.Forms.Padding(2);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(205, 37);
            this.btn_login.TabIndex = 25;
            this.btn_login.Text = "SIGN IN";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(183, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "ROLE :";
            // 
            // cboRole
            // 
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Items.AddRange(new object[] {
            "Admin",
            "Nhân Viên"});
            this.cboRole.Location = new System.Drawing.Point(370, 154);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(102, 21);
            this.cboRole.TabIndex = 29;
            // 
            // frDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(598, 486);
            this.Controls.Add(this.cboRole);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_pass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_user);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frDangNhap_FormClosing);
            this.Load += new System.EventHandler(this.frDangNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_pass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_user;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btn_exit;
        private FontAwesome.Sharp.IconButton btn_login;
        private FontAwesome.Sharp.IconButton btnSignup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboRole;
    }
}