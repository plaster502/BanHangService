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
    public class HoaDonCT
    {
        #region Properties
        private string HoaDonCT_BillID;
        private string HoaDonCT_ProductID;
        private int HoaDonCT_Num;
        private decimal HoaDonCT_Price;
        #endregion

        #region Get-set func
        [DataMember]
        public string MaHoaDon
        {
            get { return HoaDonCT_BillID; }
            set { HoaDonCT_BillID = value; }
        }
        [DataMember]
        public string MaSanPham
        {
            get { return HoaDonCT_ProductID; }
            set { HoaDonCT_ProductID = value; }
        }
        [DataMember]
        public int SoLuong
        {
            get { return HoaDonCT_Num; }
            set { HoaDonCT_Num = value; }
        }
        [DataMember]
        public decimal DonGia
        {
            get { return HoaDonCT_Price; }
            set { HoaDonCT_Price = value; }
        }
        #endregion
    }
}
