namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string MaLoaiDichVu { get; set; }

        [StringLength(255)]
        public string TenDichVu { get; set; }

        [StringLength(255)]
        public string MoTaChiTiet { get; set; }

        [StringLength(255)]
        public string Images { get; set; }

        [StringLength(100)]
        public string TinhTrang { get; set; }
    }
}
