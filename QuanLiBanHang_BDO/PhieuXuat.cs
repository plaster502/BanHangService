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
    public class PhieuXuat
    {
        #region Properties
        private string PhieuXuat_OutputID;
        private string PhieuXuat_Staff;
        private DateTime PhieuXuat_Date;
        private string PhieuXuat_Customer;
        private string PhieuXuat_Address;
        private string PhieuXuat_BillID;
        private decimal PhieuXuat_Money;
        private List<PhieuXuatCT> PhieuXuat_DetailList;
        #endregion

        #region Get-set func
        [DataMember]
        public string MaPhieuXuat
        {
            get { return PhieuXuat_OutputID; }
            set { PhieuXuat_OutputID = value; }
        }
        [DataMember]
        public string MaNhanVien
        {
            get { return PhieuXuat_Staff; }
            set { PhieuXuat_Staff = value; }
        }
        [DataMember]
        public DateTime NgayXuat
        {
            get { return PhieuXuat_Date; }
            set { PhieuXuat_Date = value; }
        }
        [DataMember]
        public string MaKhachHang
        {
            get { return PhieuXuat_Customer; }
            set { PhieuXuat_Customer = value; }
        }
        [DataMember]
        public string DiaChiGiaoHang
        {
            get { return PhieuXuat_Address; }
            set { PhieuXuat_Address = value; }
        }
        [DataMember]
        public string MaHoaDon
        {
            get { return PhieuXuat_BillID; }
            set { PhieuXuat_BillID = value; }
        }
        [DataMember]
        public decimal TongTien
        {
            get { return PhieuXuat_Money; }
            set { PhieuXuat_Money = value; }
        }
        [DataMember]
        public List<PhieuXuatCT> DSChiTiet
        {
            get { return PhieuXuat_DetailList; }
            set { PhieuXuat_DetailList = value; }
        }
        #endregion
    }
}
