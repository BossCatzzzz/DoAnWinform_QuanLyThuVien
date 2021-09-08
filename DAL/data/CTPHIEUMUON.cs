namespace DAL.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPHIEUMUON")]
    public partial class CTPHIEUMUON
    {
        public int ID { get; set; }

        public int MaSach { get; set; }

        public int SoPhieuMuon { get; set; }

        public virtual SACH SACH { get; set; }

        public virtual PHIEUMUON PHIEUMUON { get; set; }
    }
}
