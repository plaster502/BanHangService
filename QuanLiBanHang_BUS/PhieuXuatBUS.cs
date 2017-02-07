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
    public class PhieuXuatBUS
    {
        PhieuXuatDAL dal = new PhieuXuatDAL();
        public DataSet GetPhieuXuat(PhieuXuat inp, string swhere)
        {
            return dal.GetPhieuXuat(inp, swhere);
        }
    }
}
