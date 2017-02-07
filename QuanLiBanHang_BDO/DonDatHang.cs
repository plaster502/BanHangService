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
    public class DonDatHang
    {
        #region Properties
        private string DonDatHang_ID;
        private string DonDatHang_Staff;
        private string DonDatHang_Customer;
        private DateTime DonDatHang_CreateDate;
        private decimal DonDatHang_Money;
        private List<DonDatHangCT> DonDatHang_DetailList;
        #endregion

        #region Get-set func
        [DataMember]
        public string MaDonHang
        {
            get { return DonDatHang_ID; }
            set { DonDatHang_ID = value; }
        }
        [DataMember]
        public string MaNhanVien
        {
            get { return DonDatHang_Staff; }
            set { DonDatHang_Staff = value; }
        }
        [DataMember]
        public string MaKhachHang
        {
            get { return DonDatHang_Customer; }
            set { DonDatHang_Customer = value; }
        }
        [DataMember]
        public DateTime NgayTao
        {
            get { return DonDatHang_CreateDate; }
            set { DonDatHang_CreateDate = value; }
        }
        [DataMember]
        public decimal TongTien
        {
            get { return DonDatHang_Money; }
            set { DonDatHang_Money = value; }
        }
        [DataMember]
        public List<DonDatHangCT> DSChiTiet
        {
            get { return DonDatHang_DetailList; }
            set { DonDatHang_DetailList = value; }
        }
        #endregion
    }
}
