using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using QuanLiBanHang_BUS;
using QuanLiBanHang_BDO;
using QuanLiBanHang_Service.Interface;

namespace QuanLiBanHang_Service
{
    public partial class BanHangService : IDonViTinh
    {
        DonViTinhBUS DonViTinh_bus = new DonViTinhBUS();

        public List<DonViTinh> DonViTinh_GetData()
        {
            return DonViTinh_bus.GetData();
        }

        public List<DonViTinh> DonViTinh_Search(string search)
        {
            return DonViTinh_bus.Search(search);
        }

        public bool DonViTinh_Insert(DonViTinh inp)
        {
            try
            {
                return DonViTinh_bus.Insert(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DonViTinh_Update(DonViTinh inp)
        {
            try
            {
                return DonViTinh_bus.Update(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DonViTinh_Delete(int mansp)
        {
            try
            {
                return DonViTinh_bus.Delete(mansp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
