namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiKhachSan")]
    public partial class LoaiKhachSan
    {
        [Key]
        [StringLength(20)]
        public string MaLoaiKhachSan { get; set; }

        [StringLength(255)]
        public string TenLoaiKhachSan { get; set; }
    }
}
