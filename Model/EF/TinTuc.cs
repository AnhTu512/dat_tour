namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string LoaiTT { get; set; }

        [StringLength(255)]
        public string TieuDe { get; set; }

        public string MoTa { get; set; }

        public string NoiDung { get; set; }

        public string HinhAnh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDang { get; set; }
    }
}
