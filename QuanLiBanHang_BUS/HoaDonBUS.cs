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
    public class HoaDonBUS
    {
        HoaDonDAL dal = new HoaDonDAL();
        public DataSet GetHoaDon(HoaDon inp, string swhere)
        {
            return dal.GetHoaDon(inp, swhere);
        }

        public List<HoaDonCT> LoadChiTiet(string mahd)
        {
            return dal.LoadChiTiet(mahd);
        }

        public bool Insert(HoaDon inp)
        {
            return dal.Insert(inp);
        }
        public bool Update(HoaDon inp)
        {
            return dal.Update(inp);
        }
        public bool Delete(string mahd)
        {
            return dal.Delete(mahd);
        }

        public string GetNewID(int year, int month)
        {
            return dal.GetNewID(year, month);
        }
    }
}
