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
    public class NhanNgonNgu
    {
        #region Properties
        private int NhanNgonNgu_LabelID;
        private int NhanNgonNgu_LangID;
        private string NhanNgonNgu_Text;
        #endregion

        #region Get-set func
        [DataMember]
        public int MaNhan
        {
            get { return NhanNgonNgu_LabelID; }
            set { NhanNgonNgu_LabelID = value; }
        }
        [DataMember]
        public int MaNgonNgu
        {
            get { return NhanNgonNgu_LangID; }
            set { NhanNgonNgu_LangID = value; }
        }
        [DataMember]
        public string Chu
        {
            get { return NhanNgonNgu_Text; }
            set { NhanNgonNgu_Text = value; }
        }
        #endregion
    }
}
