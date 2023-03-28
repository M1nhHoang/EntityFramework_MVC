using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework_MVC.Models
{
    public partial class NhanVien
    {
        public int IdNv_145 { get; set; }
        public int MaNv_145 { get; set; }
        public string TenNv_145 { get; set; }
        public DateTime NgaySinh_145 { get; set; }
        public string GioiTinh_145 { get; set; }
        public DateTime NgayVaoCoQuan_145 { get; set; }
        public string SoCmnd_145 { get; set; }
        public double HeSoLuong_145 { get; set; }

        public virtual LoaiNhanVien IdNvNavigation { get; set; }
    }
}
