using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using DAL.data;
using DoAnWinform_QuanLyThuVien.Communication;

namespace DoAnWinform_QuanLyThuVien
{
    public partial class fDangNhap : Form
    {
        private readonly BALAction bal;
        public event communicate yes;
        public TAIKHOAN admin;
        public fDangNhap()
        {
            InitializeComponent();
            bal = new BALAction();
        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {
            btDangNhap.Enabled = false;
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn muốn thoát ?", "!!!", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //{
            //    e.Cancel = true;
            //}
        }

        private void btDangNhap_click(object sender, EventArgs e)
        {
            string err = "";
            try
            {
                //if (true)
                if (bal.KiemTraDangNhap(tbTenDangNhap.Text, textBox2.Text,out admin, out err))
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    yes();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!!!");
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                MessageBox.Show("Lỗi:\n" + err);
            }
        }


        //private void checkValidTb(object sender)
        //{
        //    TextBox tb = sender as TextBox;
        //    if (string.IsNullOrEmpty(tb.Text) || string.IsNullOrWhiteSpace(tb.Text))
        //        errorProvider1.SetError(tb, "Không được để trống!!");
        //    else
        //        errorProvider1.SetError(tb, "");
        //}

        private void login_true()
        {
            if (!string.IsNullOrEmpty(tbTenDangNhap.Text) && !string.IsNullOrWhiteSpace(tbTenDangNhap.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                btDangNhap.Enabled = true;
            }
            else
                btDangNhap.Enabled = false;
        }
        private void tbTenDangNhap_Validating(object sender, CancelEventArgs e)
        {
            bal.checkValidTb(sender,errorProvider1);
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            bal.checkValidTb(sender, errorProvider1);
        }



        private void tbTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            login_true();
        }

    }
}
