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
    
    public partial class NhanVien
    {
        public NhanVien()
        {
            this.BaoCaoNoes = new HashSet<BaoCaoNo>();
            this.BaoCaoTons = new HashSet<BaoCaoTon>();
            this.BaoGias = new HashSet<BaoGia>();
            this.DonDatHangs = new HashSet<DonDatHang>();
            this.HoaDons = new HashSet<HoaDon>();
            this.PhieuNhaps = new HashSet<PhieuNhap>();
            this.PhieuThuTiens = new HashSet<PhieuThuTien>();
            this.PhieuXuats = new HashSet<PhieuXuat>();
        }
    
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public byte[] HinhAnh { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Quyen { get; set; }
    
        public virtual ICollection<BaoCaoNo> BaoCaoNoes { get; set; }
        public virtual ICollection<BaoCaoTon> BaoCaoTons { get; set; }
        public virtual ICollection<BaoGia> BaoGias { get; set; }
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
        public virtual ICollection<PhieuThuTien> PhieuThuTiens { get; set; }
        public virtual ICollection<PhieuXuat> PhieuXuats { get; set; }
        public virtual QuyenHan QuyenHan { get; set; }
    }
}
