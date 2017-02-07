using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanHang_BDO;
using System.Data;
using System.Data.SqlClient;

namespace QuanLiBanHang_DAL
{
    public class DonViDAL
    {
        QuanLiBanHang_DAL.Model.QuanLiBanHangEntities db = new QuanLiBanHang_DAL.Model.QuanLiBanHangEntities();
        //Lấy thông tin đơn vị
        public QuanLiBanHang_BDO.DonVi GetData()
        {
            try
            {
                QuanLiBanHang_DAL.Model.DonVi query = (from donvi in db.DonVis
                                                   select donvi).FirstOrDefault();

                QuanLiBanHang_BDO.DonVi kq = null;

                if (!string.IsNullOrEmpty(query.TenDonVi))
                {
                    kq = new QuanLiBanHang_BDO.DonVi()
                    {
                        TenDonVi = query.TenDonVi,
                        Website = query.Website,
                        Facebook = query.Facebook,
                        DiaChi = query.DiaChi,
                        SoDienThoai = query.SoDienThoai,
                        Email = query.Email,
                        Fax = query.Fax,
                        MaSoThue = query.MaSoThue,
                        NganHang = query.NganHang,
                        SoTaiKhoan = query.SoTaiKhoan
                    };
                }
                return kq;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Cập nhật thông tin đơn vị
        public bool UpdateInfo(QuanLiBanHang_BDO.DonVi inp)
        {
            try
            {
                var alltable = from donvi in db.DonVis 
                               select donvi;
                foreach (QuanLiBanHang_DAL.Model.DonVi query in alltable)
                {
                    query.TenDonVi = inp.TenDonVi;
                    query.DiaChi = inp.DiaChi;
                    query.SoDienThoai = inp.SoDienThoai;
                    query.Email = inp.Email;
                    query.Fax = inp.Fax;
                    query.Website = inp.Website;
                    query.Facebook = inp.Facebook;
                    query.MaSoThue = inp.MaSoThue;
                    query.SoTaiKhoan = inp.SoTaiKhoan;
                    query.NganHang = inp.NganHang;
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
