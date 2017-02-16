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
    public partial class BanHangService : IPhieuXuat
    {
        PhieuXuatBUS PhieuXuat_bus = new PhieuXuatBUS();
        public DataSet PhieuXuat_GetPhieuXuat(PhieuXuat inp, string swhere)
        {
            try
            {
                return PhieuXuat_bus.GetPhieuXuat(inp, swhere);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PhieuXuatCT> PhieuXuat_LoadChiTiet(string mapx)
        {
            try
            {
                return PhieuXuat_bus.LoadChiTiet(mapx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool PhieuXuat_Insert(PhieuXuat inp)
        {
            try
            {
                return PhieuXuat_bus.Insert(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool PhieuXuat_Update(PhieuXuat inp)
        {
            try
            {
                return PhieuXuat_bus.Update(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool PhieuXuat_Delete(string mapx)
        {
            try
            {
                return PhieuXuat_bus.Delete(mapx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string PhieuXuat_GetNewID(int year, int month)
        {
            try
            {
                return PhieuXuat_bus.GetNewID(year, month);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
