using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace QuanLiBanHang_BDO
{
    [DataContract]
    public class NhanVien
    {
        #region Properties
        private string NhanVien_ID;
        private string NhanVien_Name;
        private DateTime NhanVien_DOB;
        private string NhanVien_Sex;
        private string NhanVien_CardID;
        private string NhanVien_Address;
        private string NhanVien_PhoneNum;
        private byte[] NhanVien_Avatar;
        private string NhanVien_Username;
        private string NhanVien_Password;
        private string NhanVien_Permission;
        #endregion

        #region Get-set func
        [DataMember]
        public string MaNhanVien
        {
            get { return NhanVien_ID; }
            set { NhanVien_ID = value; }
        }
        [DataMember]
        public string TenNhanVien
        {
            get { return NhanVien_Name; }
            set { NhanVien_Name = value; }
        }
        [DataMember]
        public DateTime NgaySinh
        {
            get { return NhanVien_DOB; }
            set { NhanVien_DOB = value; }
        }
        [DataMember]
        public string GioiTinh
        {
            get { return NhanVien_Sex; }
            set { NhanVien_Sex = value; }
        }
        [DataMember]
        public string CMND
        {
            get { return NhanVien_CardID; }
            set { NhanVien_CardID = value; }
        }
        [DataMember]
        public string DiaChi
        {
            get { return NhanVien_Address; }
            set { NhanVien_Address = value; }
        }
        [DataMember]
        public string SoDienThoai
        {
            get { return NhanVien_PhoneNum; }
            set { NhanVien_PhoneNum = value; }
        }
        [DataMember]
        public byte[] HinhAnh
        {
            get { return NhanVien_Avatar; }
            set { NhanVien_Avatar = value; }
        }
        [DataMember]
        public string TenDangNhap
        {
            get { return NhanVien_Username; }
            set { NhanVien_Username = value; }
        }
        [DataMember]
        public string MatKhau
        {
            get { return NhanVien_Password; }
            set { NhanVien_Password = value; }
        }
        [DataMember]
        public string Quyen
        {
            get { return NhanVien_Permission; }
            set { NhanVien_Permission = value; }
        }
        #endregion
    }
}
