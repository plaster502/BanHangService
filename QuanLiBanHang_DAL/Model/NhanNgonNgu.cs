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
    
    public partial class NhanNgonNgu
    {
        public int MaNhan { get; set; }
        public int MaNgonNgu { get; set; }
        public string Chu { get; set; }
    
        public virtual NgonNgu NgonNgu { get; set; }
    }
}
