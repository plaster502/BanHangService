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
    
    public partial class BaoCaoTon_CT
    {
        public string MaBaoCao { get; set; }
        public string MaSanPham { get; set; }
        public Nullable<int> TonDau { get; set; }
        public Nullable<int> PhatSinh { get; set; }
        public Nullable<int> BanRa { get; set; }
        public Nullable<int> TonCuoi { get; set; }
        public Nullable<decimal> NhapBinhQuan { get; set; }
        public Nullable<decimal> XuatBinhQuan { get; set; }
    
        public virtual BaoCaoTon BaoCaoTon { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}