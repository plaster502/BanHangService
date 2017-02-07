using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanHang_DAL;
using QuanLiBanHang_BDO;

namespace QuanLiBanHang_BUS
{
    public class NhanNgonNguBUS
    {
        private NhanNgonNguDAL dal = new NhanNgonNguDAL();

        public string GetLabel(int _mangonngu, int _manhan)
        {
            return dal.GetLabel(_mangonngu, _manhan);
        }

        public List<NhanNgonNgu> GetLabelByLang(int _mangonngu)
        {
            return dal.GetLabelByLang(_mangonngu);
        }
    }
}
