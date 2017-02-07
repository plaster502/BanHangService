using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QuanLiBanHang_BUS;
using System.Data;
using QuanLiBanHang_BDO;
using QuanLiBanHang_Service.Interface;

namespace QuanLiBanHang_Service
{
    public partial class BanHangService : IDonVi
    {
        DonViBUS DonVi_bus = new DonViBUS();

        public DonVi DonVi_GetData()
        {
            try
            {
                return DonVi_bus.GetData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DonVi_UpdateInfo(DonVi inp)
        {
            try
            {
                return DonVi_bus.UpdateInfo(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
