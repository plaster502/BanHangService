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
    public class PhieuNhap
    {
        #region Properties
        private string PhieuNhap_InputID;
        private string PhieuNhap_Staff;
        private DateTime PhieuNhap_Date;
        private decimal PhieuNhap_Money;
        private List<PhieuNhapCT> PhieuNhap_DetailList;
        #endregion

        #region Get-set func
        [DataMember]
        public string MaPhieuNhap
        {
            get { return PhieuNhap_InputID; }
            set { PhieuNhap_InputID = value; }
        }
        [DataMember]
        public string MaNhanVien
        {
            get { return PhieuNhap_Staff; }
            set { PhieuNhap_Staff = value; }
        }
        [DataMember]
        public DateTime NgayNhap
        {
            get { return PhieuNhap_Date; }
            set { PhieuNhap_Date = value; }
        }
        [DataMember]
        public decimal TongTien
        {
            get { return PhieuNhap_Money; }
            set { PhieuNhap_Money = value; }
        }
        [DataMember]
        public List<PhieuNhapCT> DSChiTiet
        {
            get { return PhieuNhap_DetailList; }
            set { PhieuNhap_DetailList = value; }
        }
        #endregion
    }
}
