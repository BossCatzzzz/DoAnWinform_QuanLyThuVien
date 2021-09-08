namespace DAL.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DOCGIA")]
    public partial class DOCGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCGIA()
        {
            PHIEUMUONs = new HashSet<PHIEUMUON>();
        }

        [Key]
        public int MaDocGia { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDocGia { get; set; }

        [Required]
        [StringLength(50)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(10)]
        public string Sdt { get; set; }

        [Required]
        [StringLength(10)]
        public string CMND { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUON> PHIEUMUONs { get; set; }
    }
}
