namespace QuanLySanBong.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("San")]
    public partial class San
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public San()
        {
            HoaDonBanHang = new HashSet<HoaDonBanHang>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSan { get; set; }

        public byte? TrangThai { get; set; }

        public int? IDLoaiSan { get; set; }

        public DateTime? NgayTao { get; set; }

        [StringLength(30)]
        public string NguoiTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        [StringLength(30)]
        public string NguoiCapNhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonBanHang> HoaDonBanHang { get; set; }

        public virtual LoaiSan LoaiSan { get; set; }
    }
}
