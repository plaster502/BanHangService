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
    public partial class BanHangService : INhanVien
    {
        NhanVienBUS NhanVien_bus = new NhanVienBUS();
        public string NhanVien_CheckLogIn(string username, string password)
        {
            try
            {
                return NhanVien_bus.CheckLogIn(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet NhanVien_GetNhanVien(NhanVien inp, string strsearch)
        {
            try
            {
                return NhanVien_bus.GetNhanVien(inp, strsearch);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public NhanVien NhanVien_GetNhanVienByID(string id)
        {
            return NhanVien_bus.GetNhanVienByID(id);
        }

        public bool NhanVien_UpdatePersonalInfo(NhanVien inp)
        {
            return NhanVien_bus.UpdatePersonalInfo(inp);
        }

        public bool NhanVien_Insert(NhanVien inp)
        {
            try
            {
                return NhanVien_bus.Insert(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool NhanVien_Update(NhanVien inp)
        {
            try
            {
                return NhanVien_bus.Update(inp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool NhanVien_Delete(string manhanvien)
        {
            try
            {
                return NhanVien_bus.Delete(manhanvien);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
