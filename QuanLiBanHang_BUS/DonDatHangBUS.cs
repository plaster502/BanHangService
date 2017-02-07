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
    public class DonDatHangBUS
    {
        private DonDatHangDAL dal = new DonDatHangDAL();

        public DataSet GetDonHang(DonDatHang inp, string swhere)
        {
            return dal.GetDonHang(inp, swhere);
        }

        public List<DonDatHangCT> LoadChiTiet(string madh)
        {
            return dal.LoadChiTiet(madh);
        }


        public bool Insert(DonDatHang inp)
        {
            return dal.Insert(inp);
        }

        public bool Update(DonDatHang inp)
        {
            return dal.Update(inp);
        }
        public bool Delete(string madh)
        {
            return dal.Delete(madh);
        }

        public string GetNewID(int year, int month)
        {
            return dal.GetNewID(year, month);
        }
    }
}
