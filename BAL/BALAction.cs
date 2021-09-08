using DAL;
using DAL.data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAL
{

    public class BALAction
    {
        private readonly DALAction dal;

        public BALAction()
        {
            dal = new DALAction();
        }

        public bool KiemTraDangNhap(string tendangnhap, string matkhau, out TAIKHOAN admin, out string er)
        {
            return dal.DALCheck_Account(tendangnhap, MD5(matkhau), out admin, out er);
        }

        public string MD5(string s)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(s));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }


        /******************************************/


        /// <summary>
        /// hàm này giúp kiểm tra coi các textbox bên trong cái control được điền đủ hay không,
        /// hàm này nhận vào 1 control thường là GroupBox hoặc Panel
        /// </summary>
        /// <param name="ct"> là cái control mà mình muốn xử lý</param>
        /// <returns>có bất kỳ textbox nào rỗng thì trả về false, ngược lại nếu tất cả đều có dữ liệu thì trả về true</returns>
        public bool checkValidInput(Control ct)
        {
            foreach (Control item in ct.Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(item.Text) || string.IsNullOrWhiteSpace(item.Text))
                {
                    MessageBox.Show("Các trường không được để trống từ BAL");
                    return false;
                }
            }
            return true;
        }

        public void checkValidTb(object sender,ErrorProvider er)
        {
            TextBox tb = sender as TextBox;
            if (string.IsNullOrEmpty(tb.Text) || string.IsNullOrWhiteSpace(tb.Text))
                er.SetError(tb, "Không được để trống!!");
            else
                er.SetError(tb, "");
        }

        public void clearTextBox(Control ct)
        {
            foreach (Control item in ct.Controls.OfType<TextBox>())
            {
                item.Text = "";
            }

        }
        public void LockInput(Control ct,bool v=true)
        {
            if(v)
            {
                foreach (TextBox item in ct.Controls.OfType<TextBox>())
                {
                    item.ReadOnly = true;
                }
            }
            else
            {
                foreach (TextBox item in ct.Controls.OfType<TextBox>())
                {
                    item.ReadOnly = false;
                }
            }
        }


        /// <summary>
        /// hàm này để chỉnh lại mấy cái cột cho hợp lý hơn
        /// cần truyền vào DatagridView cần xử lý, đối số tiếp theo truyền vào tên các cột theo đúng thứ tự, cột nào không muốn đổi thì vẫn phải để dấu cách,các tên cột cách nhau bằng 1 dấu phẩy(',')
        /// đối số cuối cùng là một mảng int chứa độ rộng của các cột theo thứ tự, cột nào muốn ẩn thì điền số 0 vào đúng vị trí đó
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="S"></param>
        /// <param name="width"></param>
        public void EditColumns(DataGridView dt, string S, int[] width = null)
        {
            string[] names = S.Split(',');
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] != " ")
                    dt.Columns[i].HeaderText = names[i];
            }
            if (width != null)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (width[i] == 0)
                    {
                        dt.Columns[i].Visible = false;
                        continue;
                    }
                    dt.Columns[i].Width = width[i];
                }
            }
        }


        public bool LaySLConLai(List<SACHDTO> list, int id)
        {

            foreach (SACHDTO item in list)
            {
                if (item.Ma_Sach == id)
                {
                    if (item.So_Luong > 0)
                    {
                        item.So_Luong--;
                        return true;
                    }
                    else return false;
                }
            }
            return true;
        }

        public string NameFix(string name)
        {
            string s = name;
            s = s.ToLower();
            s = System.Text.RegularExpressions.Regex.Replace(s, @"\s{2,}", " ");
            s = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s.ToLower());
            return s;
        }



        //****************************************  ****************************************
        //
        //
        //
        //***************************************** dưới đây là các chức năng về đọc giả *********************
        public List<DOCGIADTO> DSDocGia()
        {
            return dal.GetAllMember();
        }

        public DOCGIA TimKiemTV_MaTv(string text)
        {
            return dal.FindMember(text);
        }

        public bool ThemThanhVien(DOCGIA dg, out string err)
        {
            return dal.AddMember(dg, out err);
        }

        public bool XoaThanhVien(string id, out string err)
        {
            return dal.RemoveMember(id, out err);
        }
        public bool SuaThanhVien(DOCGIA me, out string err)
        {
            return dal.EditMember(me, out err);
        }
        public List<DOCGIADTO> TimDocGia(string text)
        {
            return dal.TimDocGia(text);
        }


        //***************************************** tới đây là hết các chức năng về đọc giả *********************
        //
        //
        //
        //***************************************** dưới đây là các chức năng về thể loại sách ******************* 
        public List<THELOAIDTO> DSTheLoai()
        {
            return dal.LayDSTheLoai();
        }

        public string[] DSTheLoaiCbb()
        {
            return dal.LayDSTLVaoComboBox();
        }

        public int LayMaTLTuTenTL(string tentl)
        {
            return dal.LayMaTLTuTenTL(tentl);
        }
        public bool ThemTheLoai(THELOAI tl, out string err)
        {
            return dal.ThemTheLoai(tl, out err);
        }
        public bool SuaTheLoai(THELOAI me, out string err)
        {
            return dal.SuaTheLoai(me, out err);
        }

        public bool XoaTheLoai(string text, out string err)
        {
            return dal.XoaTheLoai(text, out err);
        }

        //***************************************** hết các chức năng về thể loại ********************************
        //
        //
        //
        //***************************************** dưới đây là các chức năng  về sách ***************************
        public bool ThemSach(SACH s, out string err)
        {
            return dal.ThemSach(s, out err);
        }
        public List<SACHDTO> DSSach(bool checksl = false)
        {
            return dal.LayDSSach(checksl);
        }

        public List<SACHDTO> DSSachTheoLoai(string tl)
        {
            return dal.LaySachTuTheLoai(tl);
        }
        public bool XoaSach(string id, out string err)
        {
            return dal.XoaSach(id, out err);
        }

        public bool SuaSach(SACH me, out string err)
        {
            return dal.SuaSach(me, out err);
        }

        public List<SACHDTO> TimSach(string key)
        {
            return dal.TimSach(key);
        }



        //***************************************** tới đây là hết các chức năng về sách ***********************
        //
        //
        //
        //***************************************** dưới đây là các chức năng phiếu mượn ******************************
        public bool ThemPhieuMuon(PHIEUMUON pm, out string err)
        {
            return dal.ThemPhieuMuon(pm, out err);
        }
        public List<PHIEUMUONDTO> DSPhieuMuon()
        {
            return dal.DSPhieuMuon();
        }
        public bool ThemCTPM(CTPHIEUMUON ctpm, out string err)
        {
            return dal.ThemCTPM(ctpm, out err);
        }

        public List<CTPHIEUMUONDTO> LayCTPMTuMaPhieuMuon(int id)
        {
            return dal.LayCTPMTuMaPhieuMuon(id);
        }

        public bool DaTraSach(int sophiuemuon, out string err)
        {
            return dal.DaTraSach(sophiuemuon, out err);
        }

        public bool XoaPhieuMuon(string text, out string err)
        {
            return dal.XoaPhieuMuon(text, out err);
        }

        public bool SuaQTV(TAIKHOAN me, out string err)
        {
            return dal.SuaQTV(me, out err);
        }




        //public string LayHoTenTuSoPhieuMuon(string id)
        //{
        //    return dal.LayHoTenTuSoPhieuMuon(id);
        //}
    }
}
