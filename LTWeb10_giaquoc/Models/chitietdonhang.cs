namespace LTWeb10_giaquoc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chitietdonhang")]
    public partial class chitietdonhang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int madh { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int masach { get; set; }

        public int? soluong { get; set; }

        public decimal? dongia { get; set; }

        public virtual sach sach { get; set; }

        public virtual donhang donhang { get; set; }
    }
}
