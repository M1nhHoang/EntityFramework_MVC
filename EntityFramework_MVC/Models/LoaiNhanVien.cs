using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework_MVC.Models
{
    public partial class LoaiNhanVien
    {
        public LoaiNhanVien()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        public int IdNv_145 { get; set; }
        public string LoaiNv_145 { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
