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
    
    public partial class PhieuNhap_CT
    {
        public string MaPhieuNhap { get; set; }
        public string MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public Nullable<decimal> DonGia { get; set; }
    
        public virtual PhieuNhap PhieuNhap { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
