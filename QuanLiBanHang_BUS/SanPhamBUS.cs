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
    public class SanPhamBUS
    {
        private SanPhamDAL dal = new SanPhamDAL();
        //Lấy sản phẩm theo điều kiện
        public List<SanPham> GetSanPham(SanPham inp, string swhere)
        {
            List<QuanLiBanHang_DAL.Model.SanPham> dssp = dal.GetSanPham();
            if (!string.IsNullOrEmpty(inp.MaSanPham))
            {
                dssp = dssp.Where(sanpham => sanpham.MaSanPham == inp.MaSanPham).ToList();
            }
            if (!string.IsNullOrEmpty(inp.TenSanPham))
            {
                dssp = dssp.Where(sanpham => sanpham.TenSanPham == inp.TenSanPham).ToList();
            }
            if (inp.Nhom != 0)
            {
                dssp = dssp.Where(sanpham => sanpham.NhomSanPham == inp.Nhom).ToList();
            }
            if (!string.IsNullOrEmpty(swhere))
            {
                switch (swhere)
                {
                    case " and SoLuongTon > 0":
                        dssp = dssp.Where(sanpham => sanpham.SoLuongTon > 0).ToList();
                        break;
                    case " and SoLuongTon = 0":
                        dssp = dssp.Where(sanpham => sanpham.SoLuongTon == 0).ToList();
                        break;
                    default:
                        dssp = dssp.Where(sanpham => sanpham.MaSanPham.Contains(swhere) || sanpham.TenSanPham.Contains(swhere)).ToList();
                        break;
                }
            }
            List<SanPham> kq = new List<SanPham>();
            foreach (QuanLiBanHang_DAL.Model.SanPham sp in dssp)
            {
                SanPham sanpham = new SanPham
                {
                    MaSanPham = sp.MaSanPham,
                    TenSanPham = sp.TenSanPham,
                    MoTa = sp.MoTa,
                    Thue = float.Parse(sp.Thue.Value.ToString()),
                    DonViTinh = sp.DonVi.Value,
                    Nhom = sp.NhomSanPham.Value,
                    LuongTon = sp.SoLuongTon.Value
                };
                kq.Add(sanpham);
            }
            return kq;
        }
        //Tìm kiếm danh mục
        public DataSet Search(string searchInfo)
        {
            List<QuanLiBanHang_DAL.Model.SanPham> dssp = dal.GetSanPham();
            if (!string.IsNullOrEmpty(searchInfo))
            {
                dssp = dssp.Where(sanpham => sanpham.MaSanPham.ToLower().Contains(searchInfo.ToLower()) || sanpham.TenSanPham.ToLower().Contains(searchInfo.ToLower()) || sanpham.MoTa.ToLower().Contains(searchInfo.ToLower()) || sanpham.DonViTinh.TenDonViTinh.ToLower().Contains(searchInfo.ToLower()) || sanpham.NhomSanPham1.TenNhomSP.ToLower().Contains(searchInfo.ToLower())).ToList();
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSanPham");
            dt.Columns.Add("TenSanPham");
            dt.Columns.Add("MoTa");
            dt.Columns.Add("Thue");
            dt.Columns.Add("DonVi");
            dt.Columns.Add("TenDonViTinh");
            dt.Columns.Add("NhomSanPham");
            dt.Columns.Add("TenNhomSP");
            dt.Columns.Add("SoLuongTon");
            if (dssp.Count > 0)
            {
                foreach (QuanLiBanHang_DAL.Model.SanPham sp in dssp)
                {
                    DataRow row = dt.NewRow();
                    row["MaSanPham"] = sp.MaSanPham;
                    row["TenSanPham"] = sp.TenSanPham;
                    row["MoTa"] = sp.MoTa;
                    row["Thue"] = sp.Thue;
                    row["DonVi"] = sp.DonVi;
                    row["TenDonViTinh"] = sp.DonViTinh.TenDonViTinh;
                    row["NhomSanPham"] = sp.NhomSanPham;
                    row["TenNhomSP"] = sp.NhomSanPham1.TenNhomSP;
                    row["SoLuongTon"] = sp.SoLuongTon;
                    dt.Rows.Add(row);
                }
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        public bool Insert(SanPham inp)
        {
            return dal.Insert(inp);
        }

        public bool Update(SanPham inp)
        {
            return dal.Update(inp);
        }

        public bool Delete(string masp)
        {
            return dal.Delete(masp);
        }
    }
}
