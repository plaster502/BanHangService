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
    
    public partial class BaoCaoNo_CT
    {
        public string MaBaoCao { get; set; }
        public string KhachHang { get; set; }
        public Nullable<int> NoDau { get; set; }
        public Nullable<decimal> PhatSinh { get; set; }
        public Nullable<decimal> ThanhToan { get; set; }
        public Nullable<decimal> NoCuoi { get; set; }
    
        public virtual BaoCaoNo BaoCaoNo { get; set; }
        public virtual KhachHang KhachHang1 { get; set; }
    }
}
