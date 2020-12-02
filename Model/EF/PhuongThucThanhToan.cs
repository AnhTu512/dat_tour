namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhuongThucThanhToan")]
    public partial class PhuongThucThanhToan
    {
        [Key]
        [StringLength(20)]
        public string MaPT { get; set; }

        [Column("PhuongThucThanhToan")]
        [StringLength(255)]
        public string PhuongThucThanhToan1 { get; set; }
    }
}
