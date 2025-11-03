namespace LTWeb10_giaquoc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sach")]
    public partial class sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sach()
        {
            chitietdonhangs = new HashSet<chitietdonhang>();
            thamgias = new HashSet<thamgia>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int masach { get; set; }

        [StringLength(50)]
        public string tensach { get; set; }

        public decimal? giaban { get; set; }

        [StringLength(200)]
        public string mota { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaycapnhat { get; set; }

        [StringLength(200)]
        public string anhbia { get; set; }

        public int? soluongton { get; set; }

        public int? macd { get; set; }

        public int? manxb { get; set; }

        public bool? moi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietdonhang> chitietdonhangs { get; set; }

        public virtual chude chude { get; set; }

        public virtual nhaxuatban nhaxuatban { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<thamgia> thamgias { get; set; }
    }
}
