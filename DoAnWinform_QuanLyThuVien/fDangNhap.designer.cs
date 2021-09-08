namespace DoAnWinform_QuanLyThuVien
{
    partial class fDangNhap
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btDangNhap = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tbTenDangNhap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btDangNhap
            // 
            this.btDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDangNhap.Location = new System.Drawing.Point(106, 167);
            this.btDangNhap.Name = "btDangNhap";
            this.btDangNhap.Size = new System.Drawing.Size(132, 46);
            this.btDangNhap.TabIndex = 1;
            this.btDangNhap.Text = "Đăng nhập";
            this.btDangNhap.UseVisualStyleBackColor = true;
            this.btDangNhap.Click += new System.EventHandler(this.btDangNhap_click);
            // 
            // btThoat
            // 
            this.btThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.Location = new System.Drawing.Point(295, 167);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(132, 46);
            this.btThoat.TabIndex = 3;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.tbTenDangNhap);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btThoat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btDangNhap);
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 222);
            this.panel1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(244, 83);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(230, 31);
            this.textBox2.TabIndex = 1;
            this.textBox2.UseSystemPasswordChar = true;
            this.textBox2.TextChanged += new System.EventHandler(this.tbTenDangNhap_TextChanged);
            this.textBox2.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            // 
            // tbTenDangNhap
            // 
            this.tbTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTenDangNhap.Location = new System.Drawing.Point(244, 33);
            this.tbTenDangNhap.Name = "tbTenDangNhap";
            this.tbTenDangNhap.Size = new System.Drawing.Size(230, 31);
            this.tbTenDangNhap.TabIndex = 0;
            this.tbTenDangNhap.TextChanged += new System.EventHandler(this.tbTenDangNhap_TextChanged);
            this.tbTenDangNhap.Validating += new System.ComponentModel.CancelEventHandler(this.tbTenDangNhap_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // fDangNhap
            // 
            this.AcceptButton = this.btDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btThoat;
            this.ClientSize = new System.Drawing.Size(534, 247);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fClosing);
            this.Load += new System.EventHandler(this.fDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btDangNhap;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox tbTenDangNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

