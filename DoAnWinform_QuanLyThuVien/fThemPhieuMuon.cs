using BAL;
using DoAnWinform_QuanLyThuVien.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.data;
using DAL;

namespace DoAnWinform_QuanLyThuVien
{

    public partial class fThemPhieuMuon : Form
    {
        int selectedCell;
        DOCGIA dg;
        
        private readonly BALAction bal;
        public event communicate_1 oke;
 
        public fThemPhieuMuon()
        {
            InitializeComponent();
            bal = new BALAction();
            
        }

        private void fThemPhieuMuon_Load(object sender, EventArgs e)
        {
            LoadDgvChonSach();
            


            FixColumns();
        }

        private void FixColumns()
        {
            bal.EditColumns(dgvChonSach, "Mã sách,Tên sách,Số lượng, , , ", new int[] { 50, 200, 80, 0, 0, 0 });
            bal.EditColumns(dgvDanhSachChon, " , , , , , ", new int[] { 0, 200, 0, 0, 0, 0 });
            
        }

        private void dgvChonSach_DoubleClick(object sender, EventArgs e)
        {
            if (dgvChonSach.SelectedCells.Count > 0)
            {
                selectedCell = dgvChonSach.SelectedCells[0].RowIndex;
                if (!bal.LaySLConLai(list_sach_tmp, int.Parse(dgvChonSach.Rows[selectedCell].Cells[0].Value.ToString())))
                {
                    MessageBox.Show("Số lượng còn lại không đủ!");
                    return;
                }
                string cell0 = dgvChonSach.Rows[selectedCell].Cells[0].Value.ToString();
                string cell1 = dgvChonSach.Rows[selectedCell].Cells[1].Value.ToString();
                string cell2 = dgvChonSach.Rows[selectedCell].Cells[2].Value.ToString();
                string cell3 = dgvChonSach.Rows[selectedCell].Cells[3].Value.ToString();
                string cell4 = (dgvChonSach.Rows[selectedCell].Cells[4].Value == null) ? "Null" : (dgvChonSach.Rows[selectedCell].Cells[4].Value.ToString());
                string cell5 = (dgvChonSach.Rows[selectedCell].Cells[5].Value == null) ? "Null" : (dgvChonSach.Rows[selectedCell].Cells[5].Value.ToString());


                dgvDanhSachChon.Rows.Add(cell0, cell1, cell2, cell3, cell4, cell5);
 
            }
        }
        List<SACHDTO> list_sach_tmp;
        private void LoadDgvChonSach()
        {
            list_sach_tmp = bal.DSSach(true);
            dgvChonSach.DataSource = list_sach_tmp;
            dgvChonSach.ClearSelection();
        }
        private void btTaoPhieuMuon_Click(object sender, EventArgs e)
        {
            int sl = dgvDanhSachChon.Rows.Count - 1;
            if (dgvDanhSachChon.Rows.Count <= 1)
            {
               MessageBox.Show("Chưa chọn sách");
                return;
            }
            if (bal.checkValidInput(gbPhieuMuonSach))
            {
                try
                {
                    string err = "";
                    PHIEUMUON me = new PHIEUMUON();
                    me.MaDocGia = int.Parse(tbMaTv_TaoPhieuMuon.Text);
                    me.NgayHenTra = dtpNgayHenTra_taomoiPhieuMuon.Value;
                    me.NgayMuon = DateTime.Now;
                    me.SoLuongMuon = sl;

                    if (bal.ThemPhieuMuon(me, out err))
                    {
                        foreach (DataGridViewRow item in dgvDanhSachChon.Rows)
                        {
                            CTPHIEUMUON ctpm = new CTPHIEUMUON();
                            if (item.Cells[0].Value != null)
                            {
                                ctpm.MaSach = int.Parse(item.Cells[0].Value.ToString());
                                ctpm.SoPhieuMuon = me.SoPhieuMuon;

                                if (!bal.ThemCTPM(ctpm, out err))
                                {
                                    MessageBox.Show("Lỗi khi lưu chi tiết phiếu mượn!!");
                                    return;
                                }
                            }
                        }
                        MessageBox.Show("Thêm thành công!");

                        LoadDgvChonSach();
                        dgvDanhSachChon.Rows.Clear();
                        tbMaTv_TaoPhieuMuon.Text ="";
                        tbTenTV_TaoPhieuMuon.Text = "";

                        oke();
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



        private void dgvDanhSachChon_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDanhSachChon.SelectedCells.Count > 0)
            {
                selectedCell = dgvDanhSachChon.SelectedCells[0].RowIndex;
                DataGridViewRow dele = dgvDanhSachChon.Rows[selectedCell];
                dgvDanhSachChon.Rows.Remove(dele);
                foreach (SACHDTO item in list_sach_tmp)
                {
                    if(item.Ma_Sach.ToString()==dele.Cells[0].Value.ToString())
                    {
                        item.So_Luong++;
                    }
                }
            }
        }

        private void btHuyBo_TaoPhieuMUon_Click(object sender, EventArgs e)
        {
            LoadDgvChonSach();
            dgvDanhSachChon.Rows.Clear();
            tbMaTv_TaoPhieuMuon.Text = "";
            tbTenTV_TaoPhieuMuon.Text = "";
        }



        private void btTimTV_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbMaTv_TaoPhieuMuon.Text) && !string.IsNullOrWhiteSpace(tbMaTv_TaoPhieuMuon.Text))
            {
                dg = bal.TimKiemTV_MaTv(tbMaTv_TaoPhieuMuon.Text);
                if (dg != null)
                {
                    tbTenTV_TaoPhieuMuon.Text = dg.TenDocGia;
                }
                else
                {
                    MessageBox.Show("Không có thành viên với mã này!!");
                    tbMaTv_TaoPhieuMuon.Text = "";
                    tbTenTV_TaoPhieuMuon.Text = "";
                }
            }
        }

        private void btTimSach_PhieuMuon_Click(object sender, EventArgs e)
        {
            dgvChonSach.DataSource = bal.TimSach(tbTimSach_PhieuMuon.Text);
        }

        private void btHuyTim_Click(object sender, EventArgs e)
        {
            tbTimSach_PhieuMuon.Text = "";
            dgvChonSach.DataSource = list_sach_tmp;
        }
    }
}
