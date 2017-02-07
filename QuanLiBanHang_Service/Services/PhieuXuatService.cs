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
    }
}
