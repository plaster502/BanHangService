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
    public class PhieuThu
    {
        #region Properties
        private string PhieuThu_ID;
        private string PhieuThu_Customer;
        private DateTime PhieuThu_Date;
        private string PhieuThu_Staff;
        private decimal PhieuThu_Money;
        #endregion

        #region Get-set func
        [DataMember]
        public string MaPhieuThu
        {
            get { return PhieuThu_ID; }
            set { PhieuThu_ID = value; }
        }
        [DataMember]
        public string KhachHang
        {
            get { return PhieuThu_Customer; }
            set { PhieuThu_Customer = value; }
        }
        [DataMember]
        public DateTime NgayThu
        {
            get { return PhieuThu_Date; }
            set { PhieuThu_Date = value; }
        }
        [DataMember]
        public string NhanVien
        {
            get { return PhieuThu_Staff; }
            set { PhieuThu_Staff = value; }
        }
        [DataMember]
        public decimal SoTienThu
        {
            get { return PhieuThu_Money; }
            set { PhieuThu_Money = value; }
        }
        #endregion
    }
}
