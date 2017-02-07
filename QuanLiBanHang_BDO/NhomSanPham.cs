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
    public class NhomSanPham
    {
        #region Properties
        private int NhomSanPham_ID;
        private string NhomSanPham_Name;
        #endregion

        #region Get-set func
        [DataMember]
        public int MaNhomSanPham
        {
            get { return NhomSanPham_ID; }
            set { NhomSanPham_ID = value; }
        }
        [DataMember]
        public string TenNhomSanPham
        {
            get { return NhomSanPham_Name; }
            set { NhomSanPham_Name = value; }
        }
        #endregion
    }
}
