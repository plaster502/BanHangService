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
    public class PhieuNhapBUS
    {
        private PhieuNhapDAL dal = new PhieuNhapDAL();

        public DataSet GetPhieuNhap(PhieuNhap inp, string swhere)
        {
            return dal.GetPhieuNhap(inp, swhere);
        }

        public List<PhieuNhapCT> LoadChiTiet(string mapn)
        {
            return dal.LoadChiTiet(mapn);
        }

        public bool Delete(string mapn)
        {
            return dal.Delete(mapn);
        }

        public string GetNewID(int year, int month)
        {
            return dal.GetNewID(year, month);
        }

        public bool Insert(PhieuNhap inp)
        {
            return dal.Insert(inp);
        }

        public bool Update(PhieuNhap inp)
        {
            return dal.Update(inp);
        }
    }
}
