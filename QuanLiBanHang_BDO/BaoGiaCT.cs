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
    public class BaoGiaCT
    {
        #region Properties
        private string BaoGiaCT_ID;
        private string BaoGiaCT_ProductID;
        private int BaoGiaCT_Num;
        private decimal BaoGiaCT_Price;
        #endregion

        #region Get-set func
        [DataMember]
        public string MaBaoGia
        {
            get { return BaoGiaCT_ID; }
            set { BaoGiaCT_ID = value; }
        }
        [DataMember]
        public string MaSanPham
        {
            get { return BaoGiaCT_ProductID; }
            set { BaoGiaCT_ProductID = value; }
        }
        [DataMember]
        public int SoLuong
        {
            get { return BaoGiaCT_Num; }
            set { BaoGiaCT_Num = value; }
        }
        [DataMember]
        public decimal DonGia
        {
            get { return BaoGiaCT_Price; }
            set { BaoGiaCT_Price = value; }
        }
        #endregion 
    }
}
