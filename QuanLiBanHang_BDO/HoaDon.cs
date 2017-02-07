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
    public class HoaDon
    {
        #region Properties
        private string HoaDon_BillID;
        private string HoaDon_Customer;
        private string HoaDon_Staff;
        private DateTime HoaDon_Date;
        private decimal HoaDon_Money;
        private decimal HoaDon_Paid;
        private decimal HoaDon_Remain;
        private string HoaDon_Cart;
        private List<HoaDonCT> HoaDon_DetailList;
        #endregion

        #region Get-set func
        [DataMember]
        public string MaHoaDon
        {
            get { return HoaDon_BillID; }
            set { HoaDon_BillID = value; }
        }
        [DataMember]
        public string KhachHang
        {
            get { return HoaDon_Customer; }
            set { HoaDon_Customer = value; }
        }
        [DataMember]
        public string NhanVien
        {
            get { return HoaDon_Staff; }
            set { HoaDon_Staff = value; }
        }
        [DataMember]
        public DateTime NgayXuat
        {
            get { return HoaDon_Date; }
            set { HoaDon_Date = value; }
        }
        [DataMember]
        public decimal TongTien
        {
            get { return HoaDon_Money; }
            set { HoaDon_Money = value; }
        }
        [DataMember]
        public decimal DaThanhToan
        {
            get { return HoaDon_Paid; }
            set { HoaDon_Paid = value; }
        }
        [DataMember]
        public decimal ConLai
        {
            get { return HoaDon_Remain; }
            set { HoaDon_Remain = value; }
        }
        [DataMember]
        public string DonDatHang
        {
            get { return HoaDon_Cart; }
            set { HoaDon_Cart = value; }
        }
        [DataMember]
        public List<HoaDonCT> DSChiTiet
        {
            get { return HoaDon_DetailList; }
            set { HoaDon_DetailList = value; }
        }
        #endregion
    }
}
