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
    public class BaoGia
    {
        #region Properties
        private string BaoGia_ID;
        private string BaoGia_Staff;
        private DateTime BaoGia_CreateDate;
        private DateTime BaoGia_DeathDate;
        private decimal BaoGia_Money;
        private decimal BaoGia_Discount;
        private List<BaoGiaCT> BaoGia_DetailList;
        #endregion

        #region Get-set func
        [DataMember]
        public string MaBaoGia
        {
            get { return BaoGia_ID; }
            set { BaoGia_ID = value; }
        }
        [DataMember]
        public string MaNhanVien
        {
            get { return BaoGia_Staff; }
            set { BaoGia_Staff = value; }
        }
        [DataMember]
        public DateTime NgayTao
        {
            get { return BaoGia_CreateDate; }
            set { BaoGia_CreateDate = value; }
        }
        [DataMember]
        public DateTime NgayHetHan
        {
            get { return BaoGia_DeathDate; }
            set { BaoGia_DeathDate = value; }
        }
        [DataMember]
        public decimal TongTien
        {
            get { return BaoGia_Money; }
            set { BaoGia_Money = value; }
        }
        [DataMember]
        public decimal ChietKhau
        {
            get { return BaoGia_Discount; }
            set { BaoGia_Discount = value; }
        }
        [DataMember]
        public List<BaoGiaCT> DSChiTiet
        {
            get { return BaoGia_DetailList;}
            set { BaoGia_DetailList = value; }
        }
        #endregion
    }
}
