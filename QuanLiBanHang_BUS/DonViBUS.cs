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
    public class DonViBUS
    {
        private DonViDAL dal = new DonViDAL();

        public DonVi GetData()
        {
            return dal.GetData();
        }

        public bool UpdateInfo(DonVi inp)
        {
            return dal.UpdateInfo(inp);
        }
    }
}
