using DAL.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace DAL
{
    public class DALAction
    {
        public bool DALCheck_Account(string tendangnhap, string matkhau, out TAIKHOAN admin, out string er)
        {
            er = string.Empty;
            admin = null;
            try
            {
                using (ThuVienModel db = new ThuVienModel())
                {
                    admin = db.TAIKHOANs.FirstOrDefault(i => i.TenDangNhap.Equals(tendangnhap) && i.MatKhau.Equals(matkhau));
                    if (admin != null)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                er = ex.Message;
                return false;
            }
            return false;
        }
        public bool SuaQTV(TAIKHOAN me, out string err)
        {
            err = "";
            try
            {
                using (ThuVienModel db = new ThuVienModel())
                {
                    db.Entry(me).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = err + ex.Message;
                return false;
            }
        }



        //***************************************** ******************************************* *********************
        //
        //
        //
        //***************************************** ==================ĐỌC GIẢ================= ********************* 
        public List<DOCGIADTO> GetAllMember()
        {
            using (ThuVienModel DB = new ThuVienModel())
            {

                var docgiadto = from dg in DB.DOCGIAs
                                select new DOCGIADTO()
                                {
                                    ma_doc_gia = dg.MaDocGia,
                                    ten_doc_gia = dg.TenDocGia,
                                    dia_chi = dg.DiaChi,
                                    sdt = dg.Sdt,
                                    cmnd=dg.CMND
                                };
                return docgiadto.ToList();
            }
        }
        public bool AddMember(DOCGIA dg, out string err)
        {
            err = "";
            try
            {
                using (ThuVienModel db = new ThuVienModel())
                {
                    db.DOCGIAs.Add(dg);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public DOCGIA FindMember(string id)
        {
            DOCGIA dg = new DOCGIA();

            using (ThuVienModel db = new ThuVienModel())
            {
                dg = db.DOCGIAs.FirstOrDefault(i => i.MaDocGia.ToString().Equals(id));
                //return true;
            }

            return dg;
        }

        public bool RemoveMember(string id, out string err)
        {
            err = "";
            try
            {
                using (ThuVienModel db = new ThuVienModel())
                {
                    if (db.PHIEUMUONs.Any(pm => pm.DOCGIA.MaDocGia.ToString() == id))
                    {
                        err = " Đọc giả này còn đang mượn sách.\nKhông được xóa!";
                        return false;
                    }

                    DOCGIA dg = db.DOCGIAs.FirstOrDefault(i => i.MaDocGia.ToString().Equals(id));
                    db.DOCGIAs.Remove(dg);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
        public bool EditMember(DOCGIA me, out string err)
        {
            err = "";
            try
            {
                using (ThuVienModel db = new ThuVienModel())
                {
                    db.Entry(me).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = err + ex.Message;
                return false;
            }
        }

        public List<DOCGIADTO> TimDocGia(string text)
        {
            using (ThuVienModel DB = new ThuVienModel())
            {
                var tim_dg = from dg in DB.DOCGIAs
                             where dg.MaDocGia.ToString().Contains(text) ||
                                   dg.TenDocGia.ToString().Contains(text) ||
                                   dg.DiaChi.ToString().Contains(text) ||
                                   dg.Sdt.ToString().Contains(text)||
                                   dg.CMND.ToString().Equals(text)
                                   
                             select new DOCGIADTO()
                             {
                                 ma_doc_gia = dg.MaDocGia,
                                 ten_doc_gia = dg.TenDocGia,
                                 dia_chi = dg.DiaChi,
                                 sdt = dg.Sdt,
                                 cmnd=dg.CMND
                             };

                return tim_dg.ToList();
            }
        }


        //***************************************** ĐỌC GIẢ *******************************(*** *********************
        //
        //
        //
        //***************************************** THỂ LOẠI ********************************** ********************* 
        public List<THELOAIDTO> LayDSTheLoai()
        {

            using (ThuVienModel DB = new ThuVienModel())
            {

                var theloaidto = from tl in DB.THELOAIs
                                 select new THELOAIDTO()
                                 {
                                     Ma_The_Loai = tl.MaTheLoai,
                                     Ten_The_Loai = tl.TenTheLoai
                                 };

                return theloaidto.ToList();
            }
        }


        public string[] LayDSTLVaoComboBox()
        {
            using (ThuVienModel DB = new ThuVienModel())
            {
                var theloaistr = from tl in DB.THELOAIs
                                 select tl.TenTheLoai.ToString();
                return theloaistr.ToArray(); ;
            }
        }

        public int LayMaTLTuTenTL(string name)
        {
            int ID;
            using (ThuVienModel DB = new ThuVienModel())
            {
                ID = DB.THELOAIs.FirstOrDefault(tl => tl.TenTheLoai == name).MaTheLoai;


                return ID;
            }
        }

        public bool ThemTheLoai(THELOAI tl, out string err)
        {
            err = "";
            try
            {
                using (ThuVienModel db = new ThuVienModel())
                {
                    db.THELOAIs.Add(tl);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }
        public bool SuaTheLoai(THELOAI me, out string err)
        {
            err = "";
            try
            {
                using (ThuVienModel db = new ThuVienModel())
                {
                    db.Entry(me).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = err + ex.Message;
                return false;
            }
        }
        public bool XoaTheLoai(string text, out string err)
        {
            err = "";
            try
            {
                using (ThuVienModel db = new ThuVienModel())
                {
                    if (db.SACHes.Any(s => s.MaTheLoai.ToString().Equals(text)))
                    {
                        err = "Có sách thuộc loại này.\nKhông được xóa!";
                        return false;
                    }

                    THELOAI tl = db.THELOAIs.FirstOrDefault(i => i.MaTheLoai.ToString().Equals(text));
                    db.THELOAIs.Remove(tl);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }




        //*****************************************   THỂ LOẠI  ******************************************************
        //
        //
        //
        //***************************************** SÁCH ***********************************************************




        public bool DaTraSach(int sophiuemuon, out string err)
        {
            err = "";
            try
            {
                using (ThuVienModel db = new ThuVienModel())
                {
                    var ctpm = from ct in db.CTPHIEUMUONs
                               where ct.SoPhieuMuon == sophiuemuon
                               select ct;

                    foreach (CTPHIEUMUON item in ctpm.ToList())
                    {
                        SACH sach = db.SACHes.FirstOrDefault(s => s.MaSach == item.MaSach);
                        sach.SoLuong++;

                        db.Entry(sach).State = System.Data.Entity.EntityState.Modified;
                        db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    }

                    PHIEUMUON pm = db.PHIEUMUONs.FirstOrDefault(p => p.SoPhieuMuon == sophiuemuon);
                    pm.NgayTraThucTe = DateTime.Now;


                    db.Entry(pm).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = err + ex.Message;
                return false;
            }
        }



        public bool ThemSach(SACH s, out string err)
        {
            err = "Lớp DAL";
            try
            {
                using (ThuVienModel db = new ThuVienModel())
                {
                    db.SACHes.Add(s);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = err + ex.Message;

                return false;
            }
        }

        public List<SACHDTO> LayDSSach(bool checksl = false)
        {
            if (!checksl)
            {
                using (ThuVienModel DB = new ThuVienModel())
                {
                    var sachdto = from s in DB.SACHes
                                  join tl in DB.THELOAIs on s.MaTheLoai equals tl.MaTheLoai
                                  select new SACHDTO()
                                  {
                                      Ma_Sach = s.MaSach,
                                      Ten_Sach = s.TenSach,
                                      So_Luong = s.SoLuong,
                                      Ma_The_Loai = tl.TenTheLoai,
                                      Thong_Tin = s.TomTat,
                                      Tac_Gia = s.TacGia

                                  };
                    return sachdto.ToList();
                }
            }
            else
            {
                using (ThuVienModel DB = new ThuVienModel())
                {
                    var sachdtochecksl = from s in DB.SACHes
                                         join tl in DB.THELOAIs on s.MaTheLoai equals tl.MaTheLoai
                                         where s.SoLuong > 0
                                         select new SACHDTO()
                                         {
                                             Ma_Sach = s.MaSach,
                                             Ten_Sach = s.TenSach,
                                             So_Luong = s.SoLuong,
                                             Ma_The_Loai = tl.TenTheLoai,
                                             Thong_Tin = s.TomTat,
                                             Tac_Gia = s.TacGia

                                         };
                    return sachdtochecksl.ToList();
                }
            }
        }
        public List<SACHDTO> LaySachTuTheLoai(string tl)
        {

            using (ThuVienModel DB = new ThuVienModel())
            {
                var sachdto_of_category = from s in DB.SACHes
                                          join t in DB.THELOAIs on s.MaTheLoai equals t.MaTheLoai
                                          where s.MaTheLoai.ToString().Equals(tl)
                                          select new SACHDTO()
                                          {
                                              Ma_Sach = s.MaSach,
                                              Ten_Sach = s.TenSach,
                                              So_Luong = s.SoLuong,
                                              Ma_The_Loai = t.TenTheLoai,
                                              Thong_Tin = s.TomTat,
                                              Tac_Gia = s.TacGia
                                          };
                return sachdto_of_category.ToList();
            }
        }
        public List<SACHDTO> TimSach(string key)
        {
            using (ThuVienModel DB = new ThuVienModel())
            {
                var sachdto_of_category = from s in DB.SACHes
                                          where s.MaTheLoai.ToString().Contains(key) ||
                                                s.THELOAI.TenTheLoai.ToString().Contains(key) ||
                                                s.MaSach.ToString().Contains(key) ||
                                                s.TacGia.ToString().Contains(key) ||
                                                s.TenSach.ToString().Contains(key) ||
                                                s.SoLuong.ToString().Contains(key)
                                          select new SACHDTO()
                                          {
                                              Ma_Sach = s.MaSach,
                                              Ten_Sach = s.TenSach,
                                              So_Luong = s.SoLuong,
                                              Ma_The_Loai = s.THELOAI.TenTheLoai,
                                              Thong_Tin = s.TomTat,
                                              Tac_Gia = s.TacGia
                                          };
                return sachdto_of_category.ToList();
            }
        }




        public bool XoaSach(string id, out string err)
        {
            err = "";
            try
            {
                using (ThuVienModel db = new ThuVienModel())
                {

                    if (db.CTPHIEUMUONs.Any(ct => ct.SACH.MaSach.ToString().Equals(id)))
                    {
                        err = " Sách này vẫn đang có người mượn.\nKhông được xóa!";
                        return false;
                    }

                    SACH s = db.SACHes.FirstOrDefault(i => i.MaSach.ToString().Equals(id));
                    db.SACHes.Remove(s);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool SuaSach(SACH update, out string err)
        {
            err = "";
            try
            {
                using (ThuVienModel db = new ThuVienModel())
                {
                    db.Entry(update).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = err + ex.Message;
                return false;
            }
        }

        //***************************************** SÁCH ***********************************************************
        //
        //
        //
        //***************************************** PHIẾU MƯỢN ******************************************************
        public bool ThemPhieuMuon(PHIEUMUON pm, out string err)
        {
            err = "Lớp DAL";
            try
            {
                using (ThuVienModel db = new ThuVienModel())
                {
                    db.PHIEUMUONs.Add(pm);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = err + ex.Message;

                return false;
            }
        }
        public List<PHIEUMUONDTO> DSPhieuMuon()
        {
            using (ThuVienModel DB = new ThuVienModel())
            {
                var phieumuondto = from pm in DB.PHIEUMUONs
                                   join dg in DB.DOCGIAs on pm.MaDocGia equals dg.MaDocGia
                                   select new PHIEUMUONDTO()
                                   {
                                       ma_dg = pm.MaDocGia,
                                       so_phieu_muon = pm.SoPhieuMuon,
                                       ngay_hen_tra = pm.NgayHenTra,
                                       ngay_muon = pm.NgayMuon,
                                       ngay_tra_thuc = pm.NgayTraThucTe,
                                       ten_dg = dg.TenDocGia,
                                       SoLuongMuon=pm.SoLuongMuon,
                                   };
                return phieumuondto.ToList();
            }
        }

        public bool XoaPhieuMuon(string text, out string err)
        {
            err = "";
            try
            {
                using (ThuVienModel db = new ThuVienModel())
                {

                    if (db.PHIEUMUONs.Any(p => p.SoPhieuMuon.ToString().Equals(text) && p.NgayTraThucTe == null))
                    {
                        err = " Phiếu này chưa trả.\nKhông được xóa!";
                        return false;
                    }//NẾU MÀ PHIẾU NÀY CHƯA CÓ NGÀY TRẢ -> TỨC LÀ CHƯA TRẢ => KHÔNG ĐƯỢC XÓA


                    foreach (CTPHIEUMUON item in db.CTPHIEUMUONs)// BẮT ĐẦU XÓA HẾT CÁC CHI TIẾT TRƯỚC
                    {
                        if (item.SoPhieuMuon.ToString().Equals(text))// XÓA TỪNG CHI TIẾT CÓ SỐ PM = SỐ PM TRUYỀN VÀO
                        {
                            db.CTPHIEUMUONs.Remove(item);
                            //db.SaveChanges();
                        }
                    }



                    PHIEUMUON pm = db.PHIEUMUONs.FirstOrDefault(i => i.SoPhieuMuon.ToString().Equals(text));
                    db.PHIEUMUONs.Remove(pm);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }



        //***************************************** PHIẾU MƯỢN *****************************************************
        //
        //
        //
        //***************************************** CHI TIẾT PHIẾU MƯỢN**************** ******************************

        public bool ThemCTPM(CTPHIEUMUON ctpm, out string err)
        {
            /*
             * khi mà thêm dc 1 ctpm thì sl sách có mã tương ứng cũng trừ đi 1
             */

            err = "";
            try
            {
                using (ThuVienModel DB = new ThuVienModel())
                {
                    SACH sach = DB.SACHes.FirstOrDefault(s => s.MaSach == ctpm.MaSach);
                    sach.SoLuong--;
                    DB.Entry(sach).State = System.Data.Entity.EntityState.Modified;
                    DB.CTPHIEUMUONs.Add(ctpm);
                    DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public List<CTPHIEUMUONDTO> LayCTPMTuMaPhieuMuon(int id)
        {
            using (ThuVienModel DB = new ThuVienModel())
            {
                var ctpmdto = from ctpm in DB.CTPHIEUMUONs
                              where ctpm.SoPhieuMuon == id
                              select new CTPHIEUMUONDTO()
                              {
                                  id_ctpm = ctpm.ID,
                                  ma_sach = ctpm.MaSach,
                                  so_phieu_muon = ctpm.SoPhieuMuon,
                                  ten_sach = ctpm.SACH.TenSach,
                              };
                return ctpmdto.ToList();
            }
        }

        //***************************************** CHI TIẾT PHIẾU MƯỢN ******************* ***********************
        //
        //
        //
        //***************************************** dưới đây là các chức năng về   ******************************
    }
}
