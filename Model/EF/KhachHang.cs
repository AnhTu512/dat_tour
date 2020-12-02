namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        public long ID { get; set; }

        [StringLength(100)]
        public string TenKH { get; set; }

        public int? SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        public int? SoNguoiLon { get; set; }

        public int? SoTreEm { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDi { get; set; }

        [StringLength(255)]
        public string PhuongThucThanhToan { get; set; }

        public string YeuCau { get; set; }

        public int? MaTour { get; set; }

        public string TinhTrang { get; set; }
    }
}
