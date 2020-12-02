namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachSan")]
    public partial class KhachSan
    {
        public int ID { get; set; }

        [StringLength(20)]
        public string MaLoaiKhachSan { get; set; }

        public string TenKhachSan { get; set; }

        public string DiaChi { get; set; }

        [Column(TypeName = "ntext")]
        public string DonGia { get; set; }

        public string Images { get; set; }

        public string TinhTrang { get; set; }

        [StringLength(255)]
        public string LoaiKhachSan { get; set; }
    }
}
