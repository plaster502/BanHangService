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
    public partial class BanHangService : IBaoGia
    {
        BaoGiaBUS BaoGia_bus = new BaoGiaBUS();
        public DataSet BaoGia_GetBaoGia(BaoGia inp, string swhere)
        {
            try
            {
                return BaoGia_bus.GetBaoGia(inp, swhere);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BaoGiaCT> BaoGia_LoadChiTiet(string mabg)
        {
            try
            {
                return BaoGia_bus.LoadChiTiet(mabg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool BaoGia_Insert(BaoGia inp)
        {
            try
            {
                return BaoGia_bus.Insert(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool BaoGia_Update(BaoGia inp)
        {
            try
            {
                return BaoGia_bus.Update(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool BaoGia_Delete(string mabg)
        {
            try
            {
                return BaoGia_bus.Delete(mabg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string BaoGia_GetNewID(int year, int month)
        {
            try
            {
                return BaoGia_bus.GetNewID(year, month);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
