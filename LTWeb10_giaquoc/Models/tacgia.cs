namespace LTWeb10_giaquoc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tacgia")]
    public partial class tacgia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tacgia()
        {
            thamgias = new HashSet<thamgia>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int matg { get; set; }

        [StringLength(50)]
        public string tentg { get; set; }

        [StringLength(200)]
        public string diachi { get; set; }

        [StringLength(500)]
        public string tieusu { get; set; }

        [StringLength(15)]
        public string dienthoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<thamgia> thamgias { get; set; }
    }
}
