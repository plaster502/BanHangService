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

        public List<PhieuXuatCT> LoadChiTiet(string mapx)
        {
            return dal.LoadChiTiet(mapx);
        }

        public bool Insert(PhieuXuat inp)
        {
            return dal.Insert(inp);
        }
        public bool Update(PhieuXuat inp)
        {
            return dal.Update(inp);
        }
        public bool Delete(string mapx)
        {
            return dal.Delete(mapx);
        }

        public string GetNewID(int year, int month)
        {
            return dal.GetNewID(year, month);
        }
    }
}
