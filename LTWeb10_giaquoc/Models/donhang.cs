namespace LTWeb10_giaquoc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("donhang")]
    public partial class donhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public donhang()
        {
            chitietdonhangs = new HashSet<chitietdonhang>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int madh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaygiao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaydat { get; set; }

        public bool? dathanhtoan { get; set; }

        [StringLength(20)]
        public string tinhtranggiaohang { get; set; }

        public int? makh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietdonhang> chitietdonhangs { get; set; }

        public virtual khachhang khachhang { get; set; }
    }
}
