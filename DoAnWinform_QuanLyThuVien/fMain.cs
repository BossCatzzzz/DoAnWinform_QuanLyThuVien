using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using DAL;
using DAL.data;
using Microsoft.Reporting.WinForms;

namespace DoAnWinform_QuanLyThuVien
{
    public partial class fMain : Form
    {
        int selectedCell;
        private readonly BALAction bal;
        public fMain()
        {
            InitializeComponent();
            bal = new BALAction();
        }


        private void fQLSV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QUANLYTHUVIENDataSet1.showallsach' table. You can move, or remove it, as needed.



            // TODO: This line of code loads data into the 'QUANLYTHUVIENDataSet.muonnhieutrongthang' table. You can move, or remove it, as needed.

            tabcontrol1.Visible = false;
            tbTenTheLoai.ReadOnly = true;
            btHuySuaQTV.Visible = false;

            LoadDgvDocGia();
            LoadDgvTheLoai();
            LoadDgvSach();
            LoadDgvDSPM();



            FixColumns();

        }


        private void LoadDgvDSPM()
        {
            List<PHIEUMUONDTO> DSPM = bal.DSPhieuMuon();
            dgvDSPM.DataSource = DSPM;
            btDaTraPhieuMuon.Visible = false;
            dgvDSPM.ClearSelection();
            this.muonnhieutrongthangTableAdapter.Fill(this.QUANLYTHUVIENDataSet.muonnhieutrongthang, dtpforproc.Value.Month, dtpforproc.Value.Year);
            this.reportViewer2.RefreshReport();
        }

        private void LoadDgvSach()
        {
            List<SACHDTO> DSS = bal.DSSach();

            dgvSach.DataSource = DSS;

            dgvSach.ClearSelection();
            btThemSach.Enabled = true;
            btXoaSach.Enabled = btLuuSuaSach.Enabled = false;
            this.showallsachTableAdapter.Fill(this.QUANLYTHUVIENDataSet1.showallsach);
            this.reportViewer1.RefreshReport();
        }



        private void LoadDgvTheLoai()
        {
            List<THELOAIDTO> DSTL = bal.DSTheLoai();
            dgvTheLoai.DataSource = DSTL;
            cbbThuocTheLoai.DataSource = bal.DSTheLoaiCbb();
            btThemTheLoai.Enabled = true;
            dgvTheLoai.ClearSelection();

            btLuuSuaTheLoai.Enabled = btXoaTheLoai.Enabled = false;

        }

        public void LoadDgvDocGia()
        {
            dgvDocGia.DataSource = bal.DSDocGia();
            dgvDocGia.ClearSelection();
            tbMaTV.Enabled = false;
            btSuaTV.Enabled = false;
            btXoaTV.Enabled = false;
            tbMaTV.Text = null;
        }


        //================================================================================================================
        //
        //
        //================================================================================================================

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabcontrol1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabcontrol1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Aqua);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", 15.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            //dataGridViewLop.Refresh();
            //dataGridViewQTV.Refresh();
            //dgvSach.Refresh();
            //dgvKhoa.Refresh();
            //dgvDocGia.Refresh();
            LoadDgvDocGia();
            LoadDgvTheLoai();
            LoadDgvSach();
            LoadDgvDSPM();
            dgvDSCTPM.DataSource = "";
        }

        private void FixColumns()
        {
            bal.EditColumns(dgvTheLoai, " ,Thể loại", new int[] { 0, 210 });
            bal.EditColumns(dgvSach, "Mã sách,Tên sách,Số lượng,Thể loại, ,Tác Giả", new int[] { 70, 200, 70, 100, 0, 100 });
            bal.EditColumns(dgvDSPM, "Số phiếu,Ngày mượn,Hẹn trả,Ngày trả,Mã ĐG,Tên ĐG,Số lượng sách", new int[] { 65, 110, 110, 110, 70, 155,70 });
            bal.EditColumns(dgvDocGia, "Mã ĐG,Họ tên,Địa chỉ,Số điện thoại,CMND", new int[] { 80, 160, 240, 120,80 });
        }




        //================================================================================================================
        //
        //
        //================================================================================================================
        fDangNhap form;
        TAIKHOAN administrator;
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            if (!tabcontrol1.Visible)
            {
                form = new fDangNhap();
                form.yes += LoginTrue;
                form.ShowDialog();
            }
            else
            {

                tabcontrol1.Visible = false;
                btDangNhap.Text = "Đăng nhập";
            }

        }

        private void LoginTrue()
        {
            tabcontrol1.Visible = true;
            tabcontrol1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            administrator = form.admin;
            btDangNhap.Text = "Đăng xuất";
            tbHoTenQTV.Text = administrator.HoTen;
            tbTenDangNhap.Text = administrator.TenDangNhap;
            tbEmailQTV.Text = administrator.Email;
            this.Activate();
        }

        private void PhieuMuon_OKE()
        {
            LoadDgvDSPM();
            LoadDgvSach();
        }


        //================================================================================================================
        //
        //
        //==============================================    THÀNH VIÊN  ==================================================================

        private void btThemTV_Click(object sender, EventArgs e)
        {
            if (tbHoTenTV.ReadOnly)
            {
                bal.LockInput(gbTTTV, false);
                return;
            }
            else
            {
                tbMaTV.Text = "!";
                if (bal.checkValidInput(gbTTTV))
                {
                    try
                    {
                        string err = "";
                        DOCGIA me = new DOCGIA();
                        me.TenDocGia = tbHoTenTV.Text;
                        me.DiaChi = tbDiaChiTV.Text;
                        me.Sdt = tbSDTTV.Text;
                        me.CMND = tbCMND.Text;
                        if (bal.ThemThanhVien(me, out err))
                        {
                            MessageBox.Show("Thêm thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi thêm thành viên: " + err);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi " + ex.Message);
                    }
                }
            }
            bal.LockInput(gbTTTV, true);
            bal.clearTextBox(gbTTTV);
            LoadDgvDocGia();
        }

        private void btXoaTV_Click(object sender, EventArgs e)
        {
            string err = "";
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có thực sự muốn xóa?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.No)
                {
                    return;
                }
                if (bal.XoaThanhVien(tbMaTV.Text, out err))
                {
                    MessageBox.Show("Đã xóa!");
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa thành viên: " + err);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
            bal.clearTextBox(gbTTTV);
            bal.LockInput(gbTTTV, true);
            btThemTV.Enabled = true;
            LoadDgvDocGia();
            dgvDocGia.ClearSelection();

        }

        private void dgvDocGia_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDocGia.SelectedCells.Count > 0)
            {
                selectedCell = dgvDocGia.SelectedCells[0].RowIndex;
                DataGridViewRow selectrow = dgvDocGia.Rows[selectedCell];

                tbMaTV.Text = selectrow.Cells[0].Value.ToString();
                tbHoTenTV.Text = selectrow.Cells[1].Value.ToString();
                tbDiaChiTV.Text = selectrow.Cells[2].Value.ToString();
                tbSDTTV.Text = selectrow.Cells[3].Value.ToString();
                tbCMND.Text = selectrow.Cells[4].Value.ToString();

                btThemTV.Enabled = false;
                btSuaTV.Enabled = btXoaTV.Enabled = true;

            }
        }

        private void btSuaTV_Click(object sender, EventArgs e)
        {
            if (tbHoTenTV.ReadOnly)
            {
                bal.LockInput(gbTTTV, false);
                btSuaTV.Text = "Lưu";
                return;
            }
            else
            {
                DialogResult rs = MessageBox.Show("Lưu thay đổi?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.No)
                {
                    return;
                }
                if (bal.checkValidInput(gbTTTV))//không có cái tb nào trống
                {
                    try
                    {
                        string err = "";
                        DOCGIA me = new DOCGIA();
                        me.MaDocGia = int.Parse(tbMaTV.Text);
                        me.TenDocGia = tbHoTenTV.Text;
                        me.DiaChi = tbDiaChiTV.Text;
                        me.Sdt = tbSDTTV.Text;
                        me.CMND = tbCMND.Text;
                        if (bal.SuaThanhVien(me, out err))
                        {
                            MessageBox.Show("Đã lưu lại!");
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi sửa thông đọc giả: " + err);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi " + ex.Message);
                    }
                }
            }
            bal.LockInput(gbTTTV, true);
            btSuaTV.Text = "Sửa";
            bal.clearTextBox(gbTTTV);
            LoadDgvDocGia();
        }


        private void btTimTV_Click(object sender, EventArgs e)
        {
            dgvDocGia.DataSource = bal.TimDocGia(tbTimTV.Text);
        }

        private void btHuyTimTV_Click(object sender, EventArgs e)
        {
            tbTimTV.Text = "";
            LoadDgvDocGia();
        }

        private void btHuyTV_Click(object sender, EventArgs e)
        {
            bal.clearTextBox(gbTTTV);
            bal.LockInput(gbTTTV, true);
            LoadDgvDocGia();
            btThemTV.Enabled = true;
            dgvDocGia.ClearSelection();
        }
        //====================================================      THÀNH VIÊN  ======================================================
        //
        //
        //===================================================      THỂ LOẠI      ==========================================================


        private void btLuuSuaTheLoai_Click(object sender, EventArgs e)
        {
            if (tbTenTheLoai.ReadOnly)//lúc gb này dag ẩn thì tức là chưa nhấn sửa/mới load mà nhấn nút thì...
            {
                btLuuSuaTheLoai.Text = "Lưu";//nút sửa thành nút lưu
                tbTenTheLoai.ReadOnly = false;
                return;
            }
            else
            {
                DialogResult rs = MessageBox.Show("Lưu thay đổi?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.No)
                {
                    return;
                }
                if (bal.checkValidInput(gbTTTheLoai))//không có cái tb nào trống
                {
                    try
                    {
                        string err = "";
                        THELOAI me = new THELOAI();
                        me.MaTheLoai = int.Parse(tbMaTheLoai.Text);
                        me.TenTheLoai = tbTenTheLoai.Text;
                        if (bal.SuaTheLoai(me, out err))
                        {
                            MessageBox.Show("Đã lưu lại!");
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi sửa tên thể loại: " + err);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi " + ex.Message);
                    }
                }
            }
            tbTenTheLoai.ReadOnly = true;
            btLuuSuaTheLoai.Text = "Sửa";
            bal.clearTextBox(gbTTSach);
            bal.clearTextBox(gbTTTheLoai);
            LoadDgvTheLoai();
            LoadDgvSach();
        }

        private void btThemTheLoai_Click(object sender, EventArgs e)
        {
            if (tbTenTheLoai.ReadOnly)
            {
                tbTenTheLoai.ReadOnly = false;
                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(tbTenTheLoai.Text) && !string.IsNullOrWhiteSpace(tbTenTheLoai.Text))
                {
                    try
                    {
                        string err = "";
                        THELOAI me = new THELOAI(tbTenTheLoai.Text);

                        if (bal.ThemTheLoai(me, out err))
                        {
                            MessageBox.Show("Thêm thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi thêm một thể loại: " + err);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Các trường không được để trống từ BAL");
                }
            }
            tbTenTheLoai.ReadOnly = true;
            bal.clearTextBox(gbTTTheLoai);
            bal.clearTextBox(gbTTSach);
            LoadDgvTheLoai();
        }

        private void btXoaTheLoai_Click(object sender, EventArgs e)
        {
            string err = "";

            DialogResult rs = MessageBox.Show("Bạn có thực sự muốn xóa?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.No)
            {
                return;
            }

            if (bal.checkValidInput(gbTTTheLoai))
            {
                try
                {
                    if (bal.XoaTheLoai(tbMaTheLoai.Text, out err))
                    {
                        MessageBox.Show("Đã xóa!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa thể loại: " + err);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn thể loại!!!");
            }

            tbTenTheLoai.ReadOnly = true;
            bal.clearTextBox(gbTTTheLoai);
            bal.clearTextBox(gbTTSach);
            LoadDgvTheLoai();
            LoadDgvSach();
        }
        private void btHuyTheLoai_Click(object sender, EventArgs e)
        {
            tbTenTheLoai.ReadOnly = true;
            bal.clearTextBox(gbTTTheLoai);
            bal.clearTextBox(gbTTSach);
            LoadDgvTheLoai();
            LoadDgvSach();
        }

        private void dgvTheLoai_DoubleClick(object sender, EventArgs e)
        {
            if (dgvTheLoai.SelectedCells.Count > 0)
            {
                selectedCell = dgvTheLoai.SelectedCells[0].RowIndex;//          chọn ra vị trí dòng dc click
                DataGridViewRow selectrow = dgvTheLoai.Rows[selectedCell];//     lấy ra dòng đó

                tbMaTheLoai.Text = selectrow.Cells[0].Value.ToString();
                tbTenTheLoai.Text = selectrow.Cells[1].Value.ToString();


                /* 
                 * dưới đây để cho chức năng click vào cell thuộc dòng nào thì lấy ra thể loại đó 
                 * và khung dưới in ra số sách tương ứng thuộc thể loại đó
                 */

                string tl = selectrow.Cells[0].Value.ToString();// lấy ra cái mã thể loại của hàng được click
                List<SACHDTO> DSSTheoLoai = bal.DSSachTheoLoai(tl);// đưa mã thể loại trên vào hàm xuất theo loại
                dgvSach.DataSource = DSSTheoLoai;
            }
            btThemTheLoai.Enabled = false;
            btLuuSuaTheLoai.Enabled = btXoaTheLoai.Enabled = true;
            dgvSach.ClearSelection();
        }

        //===========================================      THỂ LOẠI     ===========================================================
        //
        //
        //=====================================================      SÁCH      =====================================================
        private void dgvSach_DoubleClick(object sender, EventArgs e)
        {
            if (dgvSach.SelectedCells.Count > 0)
            {
                selectedCell = dgvSach.SelectedCells[0].RowIndex;
                DataGridViewRow selectrow = dgvSach.Rows[selectedCell];

                tbMaSach.Text = selectrow.Cells[0].Value.ToString();
                tbTenSach.Text = selectrow.Cells[1].Value.ToString();
                tbSoLuong.Text = selectrow.Cells[2].Value.ToString();
                cbbThuocTheLoai.Text = selectrow.Cells[3].Value.ToString();
                tbThongTinSach.Text = (selectrow.Cells[4].Value == null) ? "null" : selectrow.Cells[4].Value.ToString();
                tbTacGia.Text = (selectrow.Cells[5].Value == null) ? "null" : selectrow.Cells[5].Value.ToString();
            }

            btThemSach.Enabled = false;
            btXoaSach.Enabled = btLuuSuaSach.Enabled = true;
        }

        private void btThemSach_Click(object sender, EventArgs e)
        {
            if (tbTenSach.ReadOnly)
            {
                bal.LockInput(gbTTSach, false);
                bal.LockInput(pnBatBuoc, false);
                cbbThuocTheLoai.Enabled = true;
                return;
            }
            else
            {
                if (bal.checkValidInput(pnBatBuoc))//không có cái tb nào trống
                {
                    try
                    {
                        string err = "";
                        SACH me = new SACH();
                        me.TenSach = tbTenSach.Text;
                        me.SoLuong = int.Parse(tbSoLuong.Text);
                        me.MaTheLoai = bal.LayMaTLTuTenTL(cbbThuocTheLoai.Text);
                        me.TomTat = (tbThongTinSach.Text == "") ? "null" : tbThongTinSach.Text;
                        me.TacGia = (tbTacGia.Text == "") ? "Chưa biết" : tbTacGia.Text;
                        if (bal.ThemSach(me, out err))
                        {
                            MessageBox.Show("Thêm thành công!");
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi thêm sách: " + err);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi " + ex.Message);
                    }
                }
            }
            bal.clearTextBox(pnBatBuoc);
            bal.LockInput(gbTTSach, true);
            bal.LockInput(pnBatBuoc, true);
            cbbThuocTheLoai.Enabled = false;
            bal.clearTextBox(gbTTSach);
            LoadDgvSach();
        }
        private void btXoaSach_Click(object sender, EventArgs e)
        {
            string err = "";
            DialogResult rs = MessageBox.Show("Bạn có thực sự muốn xóa?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.No)
            {
                return;
            }
            if (bal.checkValidInput(pnBatBuoc))
            {

                try
                {
                    if (bal.XoaSach(tbMaSach.Text, out err))
                    {
                        MessageBox.Show("Đã xóa!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa sách: " + err);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn sách!!!");
            }
            bal.LockInput(gbTTSach, true);
            bal.LockInput(pnBatBuoc, true);
            bal.clearTextBox(gbTTSach);
            LoadDgvSach();
        }
        private void btLuuSuaSach_Click(object sender, EventArgs e)// ******************** đây là chức năng sửa sách, lưu sửa sau khi nhấn nút lưu, đang lỗi~~~~~~~~~~~~~~~~~~~~~~~~~
        {
            if (tbTenSach.ReadOnly)
            {
                bal.LockInput(gbTTSach, false);
                bal.LockInput(pnBatBuoc, false);
                cbbThuocTheLoai.Enabled = true;
                btLuuSuaSach.Text = "Lưu";
                return;
            }
            else
            {
                DialogResult rs = MessageBox.Show("Lưu thay đổi?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.No)
                {
                    return;
                }
                if (bal.checkValidInput(pnBatBuoc))//không có cái tb nào trống
                {
                    try
                    {
                        string err = "";
                        SACH me = new SACH();
                        me.MaSach = int.Parse(tbMaSach.Text);
                        me.TenSach = tbTenSach.Text;
                        me.SoLuong = int.Parse(tbSoLuong.Text);
                        me.MaTheLoai = bal.LayMaTLTuTenTL(cbbThuocTheLoai.Text);
                        me.TomTat = (tbThongTinSach.Text == "") ? "null" : tbThongTinSach.Text;
                        me.TacGia = (tbTacGia.Text == "") ? "Chưa biết" : tbTacGia.Text;
                        if (bal.SuaSach(me, out err))
                        {

                            MessageBox.Show("Đã lưu lại!");
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi sửa thông tin sách: " + err);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi " + ex.Message);
                    }
                }
            }
            btLuuSuaSach.Text = "Sửa";
            bal.LockInput(gbTTSach, true);
            bal.LockInput(pnBatBuoc, true);
            cbbThuocTheLoai.Enabled = false;
            bal.clearTextBox(gbTTSach);
            bal.clearTextBox(pnBatBuoc);
            LoadDgvSach();

        }

        private void btHuySach_Click(object sender, EventArgs e)
        {
            bal.clearTextBox(gbTTSach);
            bal.clearTextBox(gbTTTheLoai);
            cbbThuocTheLoai.Enabled = false;
            bal.clearTextBox(pnBatBuoc);
            bal.LockInput(gbTTSach, true);
            bal.LockInput(pnBatBuoc, true);
            LoadDgvSach();
        }

        private void btTimSach_Click(object sender, EventArgs e)
        {
            dgvSach.DataSource = bal.TimSach(tbTimSach.Text);
        }

        private void btHuyTim_Click(object sender, EventArgs e)
        {
            tbTimSach.Text = "";
            LoadDgvSach();
        }
        //==================================================         SÁCH       ====================================================
        //
        //
        //==============================================       PHIẾU MƯỢN       ====================================================
        private void btThemPhieuMuon_Click(object sender, EventArgs e)
        {

            fThemPhieuMuon form = new fThemPhieuMuon();
            form.oke += PhieuMuon_OKE;
            //this.Hide();
            form.ShowDialog();


        }



        private void dgvDSPM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSPM.SelectedCells.Count > 0)
            {
                selectedCell = dgvDSPM.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgvDSPM.Rows[selectedCell];

                int id = int.Parse(row.Cells[0].Value.ToString());
                dgvDSCTPM.DataSource = bal.LayCTPMTuMaPhieuMuon(id);
                bal.EditColumns(dgvDSCTPM, " ,Mã sách, ,Tên sách", new int[] { 0, 100, 0, 200 });

                /****************************************************************/

                tbSoPhieuMuon.Text = row.Cells[0].Value.ToString();
                tbHoTenPhieuMuon.Text = row.Cells[5].Value.ToString();
                tbNgayMuon.Text = row.Cells[1].Value.ToString();
                tbNgayHenTra.Text = row.Cells[2].Value.ToString();
                tbNgayTra.Text = (row.Cells[3].Value == null) ? "Chưa trả" : row.Cells[3].Value.ToString();
                tbSoLuongMuon.Text = row.Cells[6].Value.ToString();

                if (tbNgayTra.Text == "Chưa trả")
                {
                    btDaTraPhieuMuon.Visible = true;
                }
                else
                    btDaTraPhieuMuon.Visible = false;

            }

        }

        private void btDaTraPhieuMuon_Click(object sender, EventArgs e)
        {
            /* khi click vào đã trả thì tiến hành thêm datetime.now vào cột đã trả của dòng dữ liệu đó
             *  sau đó thì chuyển trạng thái đã trả của tất chi tiết pm có số pm tương ứng thành true
             *  tiếp theo cộng trả sl sách lại
             */
            DialogResult rs = MessageBox.Show("Xác nhận phiếu này đã trả?", "Xác nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.No)
            {
                return;
            }

            if (bal.checkValidInput(gbPhieuMuonSach))
            {
                string err = "";
                int sophieumuon = int.Parse(tbSoPhieuMuon.Text);
                if (bal.DaTraSach(sophieumuon, out err))
                {
                    MessageBox.Show("Đã lưu lại!");
                    LoadDgvDSPM();
                    LoadDgvSach();
                    bal.clearTextBox(gbPhieuMuonSach);
                }
                else
                {
                    MessageBox.Show("Lỗi:\n " + err);
                }
            }


        }

        private void btXoaPhieuMuon_Click(object sender, EventArgs e)
        {
            string err = "";
            DialogResult rs = MessageBox.Show("Bạn có thực sự muốn xóa?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (rs == DialogResult.No)
            {
                return;
            }
            if (bal.checkValidInput(gbPhieuMuonSach))
            {
                try
                {
                    if (bal.XoaPhieuMuon(tbSoPhieuMuon.Text, out err))
                    {
                        MessageBox.Show("Đã xóa!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa: " + err);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn phiếu nào!!!");
            }

            bal.clearTextBox(gbPhieuMuonSach);
            dgvDSCTPM.DataSource = "";
            LoadDgvDSPM();

        }
        //==================================================         PHIẾU MƯỢN        ====================================================
        //
        //
        //========================================================     ADMINISTRATOR        ====================================================


        private void btHuySuaQTV_Click(object sender, EventArgs e)
        {
            bal.LockInput(gbTTQTV, true);
            btSuaQTV.Text = "Sửa";
            btHuySuaQTV.Visible = false;
        }
        private void btDoiMatKhau_Click(object sender, EventArgs e)
        {
            fDoiMK form = new fDoiMK(administrator);
            form.ShowDialog();

        }
        private void btSuaQTV_Click(object sender, EventArgs e)
        {
            if (tbTenDangNhap.ReadOnly)
            {
                bal.LockInput(gbTTQTV, false);
                btHuySuaQTV.Visible = true;
                btSuaQTV.Text = "Lưu";
                return;
            }
            else
            {
                DialogResult rs = MessageBox.Show("Lưu thay đổi?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.No)
                {
                    return;
                }
                if (bal.checkValidInput(gbTTQTV))
                {
                    try
                    {
                        string err = "";
                        TAIKHOAN me = new TAIKHOAN();
                        me.Email = tbEmailQTV.Text;
                        me.TenDangNhap = administrator.TenDangNhap;
                        me.HoTen = tbHoTenQTV.Text;
                        me.MatKhau = administrator.MatKhau;
                        if (bal.SuaQTV(me, out err))
                        {
                            MessageBox.Show("Đã lưu lại!");
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi sửa thông tin sách: " + err);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi " + ex.Message);
                    }
                }
                bal.LockInput(gbTTQTV, true);
                btSuaQTV.Text = "Sửa";
                btHuySuaQTV.Visible = false;
            }

        }

        //==================================================         ADMINISTRATOR      ====================================================
        //
        //
        //========================================================             ====================================================
        private void TextBoxLeave_NameFix(object sender, EventArgs e)//sự kiện này để chuẩn hóa tên, textbox nào dùng cái sự kiện này thì nó sẽ tự chuẩn hóa chuỗi được nhập bên trong
        {
            TextBox tb = sender as TextBox;
            tb.Text = bal.NameFix(tb.Text);
            sender = tb;
        }


        private void dtpforproc_ValueChanged(object sender, EventArgs e)
        {
            this.muonnhieutrongthangTableAdapter.Fill(this.QUANLYTHUVIENDataSet.muonnhieutrongthang, dtpforproc.Value.Month, dtpforproc.Value.Year);
            this.reportViewer2.RefreshReport();
        }


    }

}
