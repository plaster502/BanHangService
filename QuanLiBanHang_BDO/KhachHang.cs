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
    public class KhachHang
    {
        #region Properties
        private string KhachHang_ID;
        private string KhachHang_Name;
        private string KhachHang_Address;
        private string KhachHang_PhoneNum;
        private string KhachHang_Email;
        private decimal KhachHang_Owe;
        #endregion

        #region Get-set func
        [DataMember]
        public string MaKhachHang
        {
            get { return KhachHang_ID; }
            set { KhachHang_ID = value; }
        }
        [DataMember]
        public string TenKhachHang
        {
            get { return KhachHang_Name; }
            set { KhachHang_Name = value; }
        }
        [DataMember]
        public string DiaChi
        {
            get { return KhachHang_Address; }
            set { KhachHang_Address = value; }
        }
        [DataMember]
        public string SoDienThoai
        {
            get { return KhachHang_PhoneNum; }
            set { KhachHang_PhoneNum = value; }
        }
        [DataMember]
        public string Email
        {
            get { return KhachHang_Email; }
            set { KhachHang_Email = value; }
        }
        [DataMember]
        public decimal SoNo
        {
            get { return KhachHang_Owe; }
            set { KhachHang_Owe = value; }
        }
        #endregion
    }
}
