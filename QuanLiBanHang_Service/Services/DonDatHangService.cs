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
    public partial class BanHangService : IDonDatHang
    {
        DonDatHangBUS DonDatHang_bus = new DonDatHangBUS();
        public DataSet DonDatHang_GetDonHang(DonDatHang inp, string swhere)
        {
            try
            {
                return DonDatHang_bus.GetDonHang(inp, swhere);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DonDatHangCT> DonDatHang_LoadChiTiet(string madh)
        {
            try
            {
                return DonDatHang_bus.LoadChiTiet(madh);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DonDatHang_Insert(DonDatHang inp)
        {
            try
            {
                return DonDatHang_bus.Insert(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DonDatHang_Update(DonDatHang inp)
        {
            try
            {
                return DonDatHang_bus.Update(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DonDatHang_Delete(string madh)
        {
            try
            {
                return DonDatHang_bus.Delete(madh);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DonDatHang_GetNewID(int year, int month)
        {
            try
            {
                return DonDatHang_bus.GetNewID(year, month);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
