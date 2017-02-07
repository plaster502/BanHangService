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
    public partial class BanHangService : IKhachHang
    {
        KhachHangBUS KhachHang_bus = new KhachHangBUS();

        public DataSet KhachHang_GetKhachHang(KhachHang inp, string swhere)
        {
            try
            {
                return KhachHang_bus.GetKhachHang(inp, swhere);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
