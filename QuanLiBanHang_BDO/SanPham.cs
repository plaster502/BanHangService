using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace QuanLiBanHang_BDO
{
    [DataContract]
    public class SanPham
    {
        #region Properties
        private string SanPham_ID;
        private string SanPham_Name;
        private string SanPham_Describe;
        private float SanPham_Tax;
        private int SanPham_Unit;
        private int SanPham_Group;
        private int SanPham_Inven;
        #endregion

        #region Get-set func
        [DataMember]
        public string MaSanPham
        {
            get { return SanPham_ID; }
            set { SanPham_ID = value; }
        }
        [DataMember]
        public string TenSanPham
        {
            get { return SanPham_Name; }
            set { SanPham_Name = value; }
        }
        [DataMember]
        public string MoTa
        {
            get { return SanPham_Describe; }
            set { SanPham_Describe = value; }
        }
        [DataMember]
        public float Thue
        {
            get { return SanPham_Tax; }
            set { SanPham_Tax = value; }
        }
        [DataMember]
        public int DonViTinh
        {
            get { return SanPham_Unit; }
            set { SanPham_Unit = value; }
        }
        [DataMember]
        public int Nhom
        {
            get { return SanPham_Group; }
            set { SanPham_Group = value; }
        }
        [DataMember]
        public int LuongTon
        {
            get { return SanPham_Inven; }
            set { SanPham_Inven = value; }
        }
        #endregion
    }
}
