using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanHang_BDO;
using System.Data;
using System.Data.SqlClient;

namespace QuanLiBanHang_DAL
{
    public class NhanVienDAL
    {
        QuanLiBanHang_DAL.Model.QuanLiBanHangEntities db = new QuanLiBanHang_DAL.Model.QuanLiBanHangEntities();
        //Kiểm tra đăng nhập: Đúng trả về mã nhân viên, sai trả về ""
        public QuanLiBanHang_BDO.NhanVien CheckLogIn(string usernameEncrypt, string passwordEncrypt)
        {
            try
            {
                QuanLiBanHang_DAL.Model.NhanVien nv = (from nhanvien in db.NhanViens
                                                   where nhanvien.TenDangNhap == usernameEncrypt && nhanvien.MatKhau == passwordEncrypt
                                                   select nhanvien).FirstOrDefault();
                QuanLiBanHang_BDO.NhanVien kq = null;
                if (nv != null)
                {
                    kq = new NhanVien()
                    {
                        MaNhanVien = nv.MaNhanVien,
                        TenNhanVien = nv.TenNhanVien,
                        NgaySinh = nv.NgaySinh.Value,
                        GioiTinh = nv.GioiTinh,
                        CMND = nv.CMND,
                        DiaChi = nv.DiaChi,
                        SoDienThoai = nv.SoDienThoai,
                        TenDangNhap = nv.TenDangNhap,
                        MatKhau = nv.MatKhau,
                        Quyen = nv.Quyen
                    };
                    if (nv.HinhAnh != null)
                        kq.HinhAnh = nv.HinhAnh.ToArray();
                    
                }
                return kq;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Lấy danh sách nhân viên
        public DataSet GetNhanVien(QuanLiBanHang_BDO.NhanVien inp, string strsearch)
        {
            try
            {
                List<QuanLiBanHang_DAL.Model.NhanVien> dsnv = (from nhanvien in db.NhanViens
                                                   select nhanvien).ToList();
                if (!string.IsNullOrEmpty(inp.MaNhanVien))
                {
                    dsnv = dsnv.Where(nhanvien => nhanvien.MaNhanVien == inp.MaNhanVien).ToList();
                }
                if (!string.IsNullOrEmpty(inp.TenNhanVien))
                {
                    dsnv = dsnv.Where(nhanvien => nhanvien.TenNhanVien == inp.TenDangNhap).ToList();
                }
                if (!string.IsNullOrEmpty(inp.GioiTinh))
                {
                    dsnv = dsnv.Where(nhanvien => nhanvien.GioiTinh == inp.GioiTinh).ToList();
                }
                if (!string.IsNullOrEmpty(inp.CMND))
                {
                    dsnv = dsnv.Where(nhanvien => nhanvien.CMND == inp.CMND).ToList();
                }
                if (!string.IsNullOrEmpty(inp.DiaChi))
                {
                    dsnv = dsnv.Where(nhanvien => nhanvien.DiaChi == inp.DiaChi).ToList();
                }
                if (!string.IsNullOrEmpty(inp.SoDienThoai))
                {
                    dsnv = dsnv.Where(nhanvien => nhanvien.SoDienThoai == inp.SoDienThoai).ToList();
                }
                if (inp.NgaySinh.Year != 1)
                {
                    dsnv = dsnv.Where(nhanvien => nhanvien.NgaySinh == inp.NgaySinh).ToList();
                }
                if (!string.IsNullOrEmpty(strsearch))
                {
                    dsnv = dsnv.Where(nhanvien => nhanvien.MaNhanVien.ToLower().Contains(strsearch.ToLower()) || nhanvien.TenNhanVien.ToLower().Contains(strsearch.ToLower()) || nhanvien.DiaChi.ToLower().Contains(strsearch.ToLower()) || nhanvien.SoDienThoai.Contains(strsearch) || nhanvien.CMND.Contains(strsearch)).ToList();
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("MaNhanVien");
                dt.Columns.Add("TenNhanVien");
                dt.Columns.Add("NgaySinh");
                dt.Columns.Add("GioiTinh");
                dt.Columns.Add("CMND");
                dt.Columns.Add("DiaChi");
                dt.Columns.Add("SoDienThoai");
                dt.Columns.Add("HinhAnh");
                dt.Columns["HinhAnh"].DataType = System.Type.GetType("System.Byte[]");
                dt.Columns.Add("TenDangNhap");
                dt.Columns.Add("MatKhau");
                dt.Columns.Add("Quyen");
                if (dsnv.Count > 0)
                {
                    foreach (QuanLiBanHang_DAL.Model.NhanVien nv in dsnv)
                    {
                        DataRow row = dt.NewRow();
                        row["MaNhanVien"] = nv.MaNhanVien;
                        row["TenNhanVien"] = nv.TenNhanVien;
                        row["NgaySinh"] = nv.NgaySinh;
                        if (nv.GioiTinh == "Nam")
                            row["GioiTinh"] = "Nam";
                        else
                            row["GioiTinh"] = "Nữ";
                        row["CMND"] = nv.CMND;
                        row["DiaChi"] = nv.DiaChi;
                        row["SoDienThoai"] = nv.SoDienThoai;
                        if(nv.HinhAnh != null)
                            row["HinhAnh"] = nv.HinhAnh.ToArray();
                        row["TenDangNhap"] = nv.TenDangNhap;
                        row["MatKhau"] = nv.MatKhau;
                        row["Quyen"] = nv.Quyen;
                        dt.Rows.Add(row);
                    }
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Cập nhật thông tin tài khoản : Tên tài khoản, mật khẩu, ảnh đại diện
        public bool UpdatePersonalInfo(QuanLiBanHang_BDO.NhanVien inp)
        {
            try
            {
                IEnumerable<QuanLiBanHang_DAL.Model.NhanVien> dsnv = from nv in db.NhanViens
                                                                 where nv.MaNhanVien == inp.MaNhanVien
                                                                 select nv;
                QuanLiBanHang_DAL.Model.NhanVien nhanvien = dsnv.ElementAtOrDefault(0);
                if (nhanvien != null)
                {
                    nhanvien.TenDangNhap = inp.TenDangNhap;
                    nhanvien.MatKhau = inp.MatKhau;
                    if (inp.HinhAnh != null)
                        nhanvien.HinhAnh = inp.HinhAnh;
                    int kq = db.SaveChanges();
                    if (kq > 0)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Thêm nhân viên
        public bool Insert(QuanLiBanHang_BDO.NhanVien inp)
        {
            try
            {
                Model.NhanVien nvmoi = new Model.NhanVien();
                nvmoi.MaNhanVien = inp.MaNhanVien;
                nvmoi.TenNhanVien = inp.TenNhanVien;
                nvmoi.NgaySinh = inp.NgaySinh;
                if (inp.HinhAnh != null)
                    nvmoi.HinhAnh = inp.HinhAnh;
                if (inp.GioiTinh.Trim() == "Nam")
                    nvmoi.GioiTinh = inp.GioiTinh.Trim();
                else
                    nvmoi.GioiTinh = "Nu";
                nvmoi.CMND = inp.CMND;
                nvmoi.DiaChi = inp.DiaChi;
                nvmoi.SoDienThoai = inp.SoDienThoai;
                nvmoi.TenDangNhap = inp.TenDangNhap;
                nvmoi.MatKhau = inp.MatKhau;

                db.NhanViens.Add(nvmoi);
                int kq = db.SaveChanges();
                if (kq > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Cập nhật nhân viên
        public bool Update(QuanLiBanHang_BDO.NhanVien inp)
        {
            try
            {
                IEnumerable<QuanLiBanHang_DAL.Model.NhanVien> dsnv = from nv in db.NhanViens
                                                                     where nv.MaNhanVien == inp.MaNhanVien
                                                                     select nv;
                QuanLiBanHang_DAL.Model.NhanVien nhanvien = dsnv.ElementAtOrDefault(0);
                if (nhanvien != null)
                {
                    nhanvien.TenNhanVien = inp.TenNhanVien;
                    nhanvien.NgaySinh = inp.NgaySinh;
                    if (inp.HinhAnh != null)
                        nhanvien.HinhAnh = inp.HinhAnh;
                    if (inp.GioiTinh.Trim() == "Nam")
                        nhanvien.GioiTinh = inp.GioiTinh.Trim();
                    else
                        nhanvien.GioiTinh = "Nu";
                    nhanvien.CMND = inp.CMND;
                    nhanvien.DiaChi = inp.DiaChi;
                    nhanvien.SoDienThoai = inp.SoDienThoai;
                    int kq = db.SaveChanges();
                    if (kq > 0)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Xoá nhân viên
        public bool Delete(string manv)
        {
            try
            {
                IQueryable<Model.NhanVien> nhanviendelete = from nv in db.NhanViens
                                                            where nv.MaNhanVien == manv
                                                            select nv;
                if (nhanviendelete.Count() > 0)
                {
                    foreach (Model.NhanVien nv in nhanviendelete)
                    {
                        db.NhanViens.Remove(nv);
                    }
                    int kq = db.SaveChanges();
                    if (kq > 0)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
