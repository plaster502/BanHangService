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
    public partial class BanHangService : IPhieuThu
    {
        PhieuThuBUS PhieuThu_bus = new PhieuThuBUS();
        public DataSet PhieuThu_GetPhieuThu(PhieuThu inp, string swhere)
        {
            try
            {
                return PhieuThu_bus.GetPhieuThu(inp, swhere);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
