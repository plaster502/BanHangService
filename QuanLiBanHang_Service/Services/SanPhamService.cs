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
    public partial class BanHangService : ISanPham
    {
        SanPhamBUS SanPham_bus = new SanPhamBUS();

        public List<SanPham> SanPham_GetSanPham(SanPham inp, string strsearch)
        {
            try
            {
                return SanPham_bus.GetSanPham(inp, strsearch);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SanPham_Search(string searchInfo)
        {
            try
            {
                return SanPham_bus.Search(searchInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SanPham_Insert(SanPham inp)
        {
            try
            {
                return SanPham_bus.Insert(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SanPham_Update(SanPham inp)
        {
            try
            {
                return SanPham_bus.Update(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SanPham_Delete(string masp)
        {
            try
            {
                return SanPham_bus.Delete(masp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
