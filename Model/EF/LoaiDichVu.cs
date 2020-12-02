namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiDichVu")]
    public partial class LoaiDichVu
    {
        [Key]
        [StringLength(20)]
        public string MaLoaiDichVu { get; set; }

        [StringLength(255)]
        public string TenLoaiDichVu { get; set; }
    }
}
