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
    
    public partial class DonViTinh
    {
        public DonViTinh()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
    
        public int MaDonViTinh { get; set; }
        public string TenDonViTinh { get; set; }
    
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}