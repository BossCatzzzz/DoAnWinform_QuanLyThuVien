using BAL;
using DAL.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnWinform_QuanLyThuVien
{
    public partial class fDoiMK : Form
    {
        TAIKHOAN admin;
        private readonly BALAction bal;
        public fDoiMK()
        {
            InitializeComponent();
            
        }
        public fDoiMK(TAIKHOAN tk)
        {
            InitializeComponent();
            bal = new BALAction();
            admin = tk;
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            
            if(textBox1.Text==textBox2.Text)
            {
                string err = "";
                admin.MatKhau = bal.MD5(textBox1.Text);
                if(bal.SuaQTV(admin,out err))
                {
                    MessageBox.Show("Đã lưu!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra!\n" + err);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp.\nVui lòng kiểm tra lại!");
            }
        }

        private void btHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            bal.checkValidTb(sender, errorProvider1);
        }
    }
}
