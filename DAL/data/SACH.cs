namespace DAL.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            CTPHIEUMUONs = new HashSet<CTPHIEUMUON>();
        }

        [Key]
        public int MaSach { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSach { get; set; }

        public int SoLuong { get; set; }

        public int MaTheLoai { get; set; }

        [StringLength(50)]
        public string TomTat { get; set; }

        [StringLength(50)]
        public string TacGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUMUON> CTPHIEUMUONs { get; set; }

        public virtual THELOAI THELOAI { get; set; }
    }
}
