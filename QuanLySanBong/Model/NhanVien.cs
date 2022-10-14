namespace QuanLySanBong.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(50)]
        public string HoVaTen { get; set; }

        [StringLength(30)]
        public string DienThoai { get; set; }

        [StringLength(150)]
        public string DiaChi { get; set; }
    }
}
