namespace DAL.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUMUON")]
    public partial class PHIEUMUON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUMUON()
        {
            CTPHIEUMUONs = new HashSet<CTPHIEUMUON>();
        }

        [Key]
        public int SoPhieuMuon { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayMuon { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayHenTra { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTraThucTe { get; set; }

        public int MaDocGia { get; set; }

        public int SoLuongMuon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUMUON> CTPHIEUMUONs { get; set; }

        public virtual DOCGIA DOCGIA { get; set; }
    }
}
