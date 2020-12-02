namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiTour")]
    public partial class LoaiTour
    {
        [Key]
        [StringLength(20)]
        public string MaLoaiTour { get; set; }

        public string TenLoaiTour { get; set; }
    }
}
