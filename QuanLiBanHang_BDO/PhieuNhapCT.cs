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
    public class PhieuNhapCT
    {
        #region Properties
        private string PhieuNhapCT_InputID;
        private string PhieuNhapCT_ProductID;
        private int PhieuNhapCT_Num;
        private decimal PhieuNhapCT_Price;
        #endregion

        #region Get-set func
        [DataMember]
        public string MaPhieuNhap
        {
            get { return PhieuNhapCT_InputID; }
            set { PhieuNhapCT_InputID = value; }
        }
        [DataMember]
        public string MaSanPham
        {
            get { return PhieuNhapCT_ProductID; }
            set { PhieuNhapCT_ProductID = value; }
        }
        [DataMember]
        public int SoLuong
        {
            get { return PhieuNhapCT_Num; }
            set { PhieuNhapCT_Num = value; }
        }
        [DataMember]
        public decimal DonGia
        {
            get { return PhieuNhapCT_Price; }
            set { PhieuNhapCT_Price = value; }
        }
        #endregion
    }
}
