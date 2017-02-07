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
    public class DonViTinh
    {
        #region Properties
        private int DonViTinh_ID;
        private string DonViTinh_Name;
        #endregion

        #region Get-set func
        [DataMember]
        public int MaDonViTinh
        {
            get { return DonViTinh_ID; }
            set { DonViTinh_ID = value; }
        }
        [DataMember]
        public string TenDonViTinh
        {
            get { return DonViTinh_Name; }
            set { DonViTinh_Name = value; }
        }
        #endregion
    }
}
