using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace QuanLiBanHang_BDO
{
    [DataContract]
    public class DonVi
    {
        #region Properties
        private string DonVi_Name;
        private string DonVi_Address;
        private string DonVi_PhoneNum;
        private string DonVi_Email;
        private string DonVi_Fax;
        private string DonVi_Website;
        private string DonVi_Facebook;
        private string DonVi_TaxCode;
        private string DonVi_BankAccount;
        private string DonVi_Bank;
        #endregion

        #region Get-set func
        [DataMember]
        public string TenDonVi
        {
            get { return DonVi_Name; }
            set { DonVi_Name = value; }
        }
        [DataMember]
        public string DiaChi
        {
            get { return DonVi_Address; }
            set { DonVi_Address = value; }
        }
        [DataMember]
        public string SoDienThoai
        {
            get { return DonVi_PhoneNum; }
            set { DonVi_PhoneNum = value; }
        }
        [DataMember]
        public string Email
        {
            get { return DonVi_Email; }
            set { DonVi_Email = value; }
        }
        [DataMember]
        public string Fax
        {
            get { return DonVi_Fax; }
            set { DonVi_Fax = value; }
        }
        [DataMember]
        public string Website
        {
            get { return DonVi_Website; }
            set { DonVi_Website = value; }
        }
        [DataMember]
        public string Facebook
        {
            get { return DonVi_Facebook; }
            set { DonVi_Facebook = value; }
        }
        [DataMember]
        public string MaSoThue
        {
            get { return DonVi_TaxCode; }
            set { DonVi_TaxCode = value; }
        }
        [DataMember]
        public string SoTaiKhoan
        {
            get { return DonVi_BankAccount; }
            set { DonVi_BankAccount = value; }
        }
        [DataMember]
        public string NganHang
        {
            get { return DonVi_Bank; }
            set { DonVi_Bank = value; }
        }
        #endregion
    }
}
