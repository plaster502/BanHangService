using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace QuanLiBanHang_BDO
{
    [DataContract]
    public class DonDatHangCT
    {
        #region Properties
        private string DonDatHangCT_ID;
        private string DonDatHangCT_ProductID;
        private int DonDatHangCT_Num;
        private decimal DonDatHangCT_Price;
        #endregion

        #region Get-set func
        [DataMember]
        public string MaDonDatHang
        {
            get { return DonDatHangCT_ID; }
            set { DonDatHangCT_ID = value; }
        }
        [DataMember]
        public string MaSanPham
        {
            get { return DonDatHangCT_ProductID; }
            set { DonDatHangCT_ProductID = value; }
        }
        [DataMember]
        public int SoLuong
        {
            get { return DonDatHangCT_Num; }
            set { DonDatHangCT_Num = value; }
        }
        [DataMember]
        public decimal DonGia
        {
            get { return DonDatHangCT_Price; }
            set { DonDatHangCT_Price = value; }
        }
        #endregion 
    }
}
