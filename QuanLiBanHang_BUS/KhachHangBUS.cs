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
    public class KhachHangBUS
    {
        KhachHangDAL dal = new KhachHangDAL();

        public DataSet GetKhachHang(KhachHang inp, string swhere)
        {
            return dal.GetKhachHang(inp, swhere);
        }
    }
}
