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
    public partial class BanHangService : IHoaDon
    {
        HoaDonBUS HoaDon_bus = new HoaDonBUS();
        public DataSet HoaDon_GetHoaDon(HoaDon inp, string swhere)
        {
            try
            {
                return HoaDon_bus.GetHoaDon(inp, swhere);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HoaDonCT> HoaDon_LoadChiTiet(string mahd)
        {
            try
            {
                return HoaDon_bus.LoadChiTiet(mahd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool HoaDon_Insert(HoaDon inp)
        {
            try
            {
                return HoaDon_bus.Insert(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool HoaDon_Update(HoaDon inp)
        {
            try
            {
                return HoaDon_bus.Update(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool HoaDon_Delete(string mahd)
        {
            try
            {
                return HoaDon_bus.Delete(mahd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string HoaDon_GetNewID(int year, int month)
        {
            try
            {
                return HoaDon_bus.GetNewID(year, month);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
