namespace LTWeb10_giaquoc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("khachhang")]
    public partial class khachhang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int makh { get; set; }

        [StringLength(200)]
        public string hoten { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysinh { get; set; }

        [StringLength(3)]
        public string gioitinh { get; set; }

        [StringLength(15)]
        public string dienthoai { get; set; }

        [StringLength(200)]
        public string taikhoan { get; set; }

        [StringLength(500)]
        public string matkhau { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(200)]
        public string diachi { get; set; }

        public virtual donhang donhang { get; set; }
    }
}
