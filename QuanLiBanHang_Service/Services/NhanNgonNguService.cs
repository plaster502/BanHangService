using System;
using System.Collections.Generic;
using QuanLiBanHang_Service.Interface;
using QuanLiBanHang_BUS;
using QuanLiBanHang_BDO;

namespace QuanLiBanHang_Service
{
    public partial class BanHangService : INhanNgonNgu
    {
        NhanNgonNguBUS Nhan_bus = new NhanNgonNguBUS();

        public string NhanNgonNgu_GetLabel(int _mangonngu, int _manhan)
        {
            try
            {
                return Nhan_bus.GetLabel(_mangonngu, _manhan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NhanNgonNgu> NhanNgonNgu_GetLabelByLang(int _mangonngu)
        {
            try
            {
                return Nhan_bus.GetLabelByLang(_mangonngu);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
