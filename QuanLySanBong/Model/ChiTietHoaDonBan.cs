namespace QuanLySanBong.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDonBan")]
    public partial class ChiTietHoaDonBan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDHoaDon { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDMatHang { get; set; }

        public int? SoLuong { get; set; }

        public int? DonGia { get; set; }

        public virtual HoaDonBanHang HoaDonBanHang { get; set; }

        public virtual MatHang MatHang { get; set; }
    }
}
