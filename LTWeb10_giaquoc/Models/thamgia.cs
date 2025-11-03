namespace LTWeb10_giaquoc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("thamgia")]
    public partial class thamgia
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int masach { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int matg { get; set; }

        [StringLength(50)]
        public string vaitro { get; set; }

        [StringLength(50)]
        public string vitri { get; set; }

        public virtual sach sach { get; set; }

        public virtual tacgia tacgia { get; set; }
    }
}
