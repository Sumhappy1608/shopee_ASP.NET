namespace Model.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HANGHOA")]
    public partial class HANGHOA
    {
        [Key]
        [StringLength(15)]
        public string MAHANGHOA { get; set; }

        [Required]
        [StringLength(60)]
        public string TENHANGHOA { get; set; }

        public string MOTA { get; set; }

        public double GIATHANH { get; set; }

        public int SOLUONGTON { get; set; }

        [Required]
        [StringLength(10)]
        public string LOAIHANGHOA { get; set; }

        [Required]
        [StringLength(3)]
        public string HHFlag { get; set; }

        public double? DANHGIA_HANGHOA { get; set; }

        public DateTime? THOIHANSUDUNG { get; set; }

        public int? SOLUONGDABAN { get; set; }

        public string HINHANH { get; set; }
    }
}
