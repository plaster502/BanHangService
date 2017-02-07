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
    public partial class BanHangService : IPhieuNhap
    {
        PhieuNhapBUS PhieuNhap_bus = new PhieuNhapBUS();
        public DataSet PhieuNhap_GetPhieuNhap(PhieuNhap inp, string swhere)
        {
            try
            {
                return PhieuNhap_bus.GetPhieuNhap(inp, swhere);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PhieuNhapCT> PhieuNhap_LoadChiTiet(string mapn)
        {
            try
            {
                return PhieuNhap_bus.LoadChiTiet(mapn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool PhieuNhap_Insert(PhieuNhap inp)
        {
            try
            {
                return PhieuNhap_bus.Insert(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool PhieuNhap_Update(PhieuNhap inp)
        {
            try
            {
                return PhieuNhap_bus.Update(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool PhieuNhap_Delete(string mapn)
        {
            try
            {
                return PhieuNhap_bus.Delete(mapn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string PhieuNhap_GetNewID(int year, int month)
        {
            try
            {
                return PhieuNhap_bus.GetNewID(year, month);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
