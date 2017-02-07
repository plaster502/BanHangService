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
    public partial class BanHangService : INhomSanPham
    {
        NhomSanPhamBUS NhomSanPham_bus = new NhomSanPhamBUS();

        public List<NhomSanPham> NhomSanPham_GetData()
        {
            return NhomSanPham_bus.GetData();
        }

        public List<NhomSanPham> NhomSanPham_Search(string search)
        {
            return NhomSanPham_bus.Search(search);
        }

        public bool NhomSanPham_Insert(NhomSanPham inp)
        {
            try
            {
                return NhomSanPham_bus.Insert(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool NhomSanPham_Update(NhomSanPham inp)
        {
            try
            {
                return NhomSanPham_bus.Update(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool NhomSanPham_Delete(int mansp)
        {
            try
            {
                return NhomSanPham_bus.Delete(mansp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
