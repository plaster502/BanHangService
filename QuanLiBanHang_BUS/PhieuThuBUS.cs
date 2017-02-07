using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanHang_DAL;
using QuanLiBanHang_BDO;
using System.Data;

namespace QuanLiBanHang_BUS
{
    public class PhieuThuBUS
    {
        private PhieuThuDAL dal = new PhieuThuDAL();

        public DataSet GetPhieuThu(PhieuThu inp, string swhere)
        {
            return dal.GetPhieuThu(inp, swhere);
        }
    }
}
