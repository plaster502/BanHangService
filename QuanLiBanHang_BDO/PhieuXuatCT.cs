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
    public class PhieuXuatCT
    {
        #region Properties
        private string PhieuXuatCT_OutputID;
        private string PhieuXuatCT_ProductID;
        private int PhieuXuatCT_Num;
        private int PhieuXuatCT_NumReal;
        private decimal PhieuXuatCT_Price;
        #endregion

        #region Get-set func
        [DataMember]
        public string MaPhieuXuat
        {
            get { return PhieuXuatCT_OutputID; }
            set { PhieuXuatCT_OutputID = value; }
        }
        [DataMember]
        public string MaSanPham
        {
            get { return PhieuXuatCT_ProductID; }
            set { PhieuXuatCT_ProductID = value; }
        }
        [DataMember]
        public int SoLuongYeuCau
        {
            get { return PhieuXuatCT_Num; }
            set { PhieuXuatCT_Num = value; }
        }
        [DataMember]
        public int SoLuongThuc
        {
            get { return PhieuXuatCT_NumReal; }
            set { PhieuXuatCT_NumReal = value; }
        }
        [DataMember]
        public decimal DonGia
        {
            get { return PhieuXuatCT_Price; }
            set { PhieuXuatCT_Price = value; }
        }
        #endregion
    }
}
