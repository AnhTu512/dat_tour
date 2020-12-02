namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tour")]
    public partial class Tour
    {
        public long ID { get; set; }

        [StringLength(12)]
        public string MaLoaiTour { get; set; }

        [StringLength(100)]
        public string TenTour { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        public string LichTrinh { get; set; }

        [StringLength(255)]
        public string BangGia { get; set; }

        public string ThongTinLienQuan { get; set; }

        public string Images { get; set; }

        public string TinhTrang { get; set; }

        public string DiaDiemKhoiHanh { get; set; }

        public string ThoiLuong { get; set; }

        public string DiemDen { get; set; }

        [StringLength(100)]
        public string PhuongTien { get; set; }

        [StringLength(100)]
        public string LienHe { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCapNhat { get; set; }
    }
}
