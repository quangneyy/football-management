namespace QuanLySanBong.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonBanHang")]
    public partial class HoaDonBanHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonBanHang()
        {
            ChiTietHoaDonBan = new HashSet<ChiTietHoaDonBan>();
        }

        [Key]
        public int IDHoaDon { get; set; }

        public int? IDSan { get; set; }

        public DateTime? ThoiGianBDau { get; set; }

        public DateTime? ThoiGianKetThuc { get; set; }

        public int? DonGiaSan { get; set; }

        public DateTime? NgayBan { get; set; }

        [StringLength(30)]
        public string NguoiBan { get; set; }

        public DateTime? NgayTao { get; set; }

        [StringLength(30)]
        public string NguoiTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        [StringLength(50)]
        public string NguoiCapNhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonBan> ChiTietHoaDonBan { get; set; }

        public virtual San San { get; set; }
    }
}
