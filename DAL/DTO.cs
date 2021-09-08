using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class THELOAIDTO
    {
        public int Ma_The_Loai { get; set; }
        public string Ten_The_Loai { get; set; }
    }

    public class THELOAItoSTRING
    {
        public string the_loai { get; set; }
    }
    public class SACHDTO
    {

        public int Ma_Sach { get; set; }
        public string Ten_Sach { get; set; }
        public int So_Luong { get; set; }

        public string Ma_The_Loai { get; set; }
        public string Thong_Tin { get; set; }
        public string Tac_Gia { get; set; }
    }

    public class SACHDTO_TEMPLATE
    {
        public int Ma_Sach { get; set; }
        public int So_Luong { get; set; }
    }

    public class DOCGIADTO
    {
        public int ma_doc_gia { get; set; }
        public string ten_doc_gia { get; set; }
        public string dia_chi { get; set; }
        public string sdt { get; set; }

        public string cmnd { get; set; }
    }

   public class PHIEUMUONDTO
    {
        public int so_phieu_muon { get; set; }

        public DateTime ngay_muon { get; set; }

        public DateTime ngay_hen_tra { get; set; }

        public DateTime? ngay_tra_thuc { get; set; }

        public int ma_dg { get; set; }

        public string ten_dg { get; set; }

        public int SoLuongMuon { get; set; }
    }

    public class CTPHIEUMUONDTO
    {
        public int id_ctpm { get; set; }

        public int ma_sach { get; set; }

        public int so_phieu_muon { get; set; }
        public string ten_sach { get; set; }
        

    }
}

