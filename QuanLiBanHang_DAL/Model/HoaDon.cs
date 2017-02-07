//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLiBanHang_DAL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDon
    {
        public HoaDon()
        {
            this.HoaDon_CT = new HashSet<HoaDon_CT>();
            this.PhieuXuats = new HashSet<PhieuXuat>();
        }
    
        public string MaHoaDon { get; set; }
        public string KhachHang { get; set; }
        public string NhanVien { get; set; }
        public Nullable<System.DateTime> NgayXuat { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public Nullable<decimal> DaThanhToan { get; set; }
        public Nullable<decimal> ConLai { get; set; }
        public string DonHang { get; set; }
    
        public virtual DonDatHang DonDatHang { get; set; }
        public virtual ICollection<HoaDon_CT> HoaDon_CT { get; set; }
        public virtual KhachHang KhachHang1 { get; set; }
        public virtual NhanVien NhanVien1 { get; set; }
        public virtual ICollection<PhieuXuat> PhieuXuats { get; set; }
    }
}