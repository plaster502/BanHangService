using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanHang_DAL;
using QuanLiBanHang_BDO;
using System.Data;

namespace QuanLiBanHang_BUS
{
    public class NhanVienBUS
    {
        private NhanVienDAL dal = new NhanVienDAL();

        public string CheckLogIn(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return "";
            }
            else
            {
                NhanVien nv = dal.CheckLogIn(MaHoa.Encrypt(username,true),MaHoa.Encrypt(password,true));
                if (!string.IsNullOrEmpty(nv.MaNhanVien))
                {
                    return nv.MaNhanVien;
                }
                else
                {
                    return "";
                }
            }
        }

        public DataSet GetNhanVien(NhanVien inp, string strsearch)
        {
            return dal.GetNhanVien(inp, strsearch);
        }

        public NhanVien GetNhanVienByID(string id)
        {
            NhanVien nv = new NhanVien();
            nv.MaNhanVien = id;
            DataSet ds = dal.GetNhanVien(nv, "");
            NhanVien kq = new NhanVien();
            if(ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                kq.MaNhanVien = ds.Tables[0].Rows[0]["MaNhanVien"].ToString();
                kq.TenNhanVien = ds.Tables[0].Rows[0]["TenNhanVien"].ToString();
                kq.NgaySinh = Convert.ToDateTime(ds.Tables[0].Rows[0]["NgaySinh"].ToString());
                kq.GioiTinh = ds.Tables[0].Rows[0]["GioiTinh"].ToString();
                kq.CMND = ds.Tables[0].Rows[0]["CMND"].ToString();
                kq.DiaChi = ds.Tables[0].Rows[0]["DiaChi"].ToString();
                kq.SoDienThoai = ds.Tables[0].Rows[0]["SoDienThoai"].ToString();
                kq.TenDangNhap = MaHoa.Decrypt(ds.Tables[0].Rows[0]["TenDangNhap"].ToString(), true);
                kq.MatKhau = MaHoa.Decrypt(ds.Tables[0].Rows[0]["MatKhau"].ToString(), true);
                kq.Quyen = ds.Tables[0].Rows[0]["Quyen"].ToString();
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["HinhAnh"].ToString()) == true)
                {
                    kq.HinhAnh = null;
                }
                else
                {
                    kq.HinhAnh = (byte[])ds.Tables[0].Rows[0]["HinhAnh"];
                }
            }
            return kq;
        }

        public bool UpdatePersonalInfo(NhanVien inp)
        {
            inp.TenDangNhap = MaHoa.Encrypt(inp.TenDangNhap, true);
            inp.MatKhau = MaHoa.Encrypt(inp.MatKhau, true);
            return dal.UpdatePersonalInfo(inp);
        }

        public bool Insert(NhanVien inp)
        {
            inp.TenDangNhap = MaHoa.Encrypt(inp.MaNhanVien,true);
            inp.MatKhau = MaHoa.Encrypt("1", true);
            return dal.Insert(inp);
        }

        public bool Update(NhanVien inp)
        {
            return dal.Update(inp);
        }

        public bool Delete(string manhanvien)
        {
            return dal.Delete(manhanvien);
        }
    }
}
