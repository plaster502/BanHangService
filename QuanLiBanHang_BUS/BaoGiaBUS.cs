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
    public class BaoGiaBUS
    {
        private BaoGiaDAL dal = new BaoGiaDAL();

        public DataSet GetBaoGia(BaoGia inp, string swhere)
        {
            return dal.GetBaoGia(inp, swhere);
        }

        public List<BaoGiaCT> LoadChiTiet(string mabg)
        {
            return dal.LoadChiTiet(mabg);
        }

        public bool Insert(BaoGia inp)
        {
            return dal.Insert(inp);
        }

        public bool Update(BaoGia inp)
        {
            return dal.Update(inp);
        }

        public bool Delete(string mabg)
        {
            return dal.Delete(mabg);
        }

        public string GetNewID(int year, int month)
        {
            return dal.GetNewID(year, month);
        }
    }
}
