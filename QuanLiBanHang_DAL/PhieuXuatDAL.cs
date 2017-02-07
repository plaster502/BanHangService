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
    public class PhieuXuatDAL
    {
        QuanLiBanHang_DAL.Model.QuanLiBanHangEntities db = new QuanLiBanHang_DAL.Model.QuanLiBanHangEntities();
        //Lấy danh sách phiếu xuất
        public DataSet GetPhieuXuat(PhieuXuat inp, string swhere)
        {
            try
            {
                List<Model.PhieuXuat> dspx = (from px in db.PhieuXuats
                                                 select px).ToList();
                if (!string.IsNullOrEmpty(inp.MaPhieuXuat))
                {
                    dspx = dspx.Where(phieuxuat => phieuxuat.MaPhieuXuat == inp.MaPhieuXuat).ToList();
                }
                if (!string.IsNullOrEmpty(inp.MaNhanVien))
                {
                    dspx = dspx.Where(phieuxuat => phieuxuat.NhanVien == inp.MaNhanVien).ToList();
                }
                if (!string.IsNullOrEmpty(inp.MaKhachHang))
                {
                    dspx = dspx.Where(phieuxuat => phieuxuat.KhachHang == inp.MaKhachHang).ToList();
                }
                if (inp.NgayXuat.Year != 1)
                {
                    dspx = dspx.Where(phieuxuat => phieuxuat.NgayXuat == inp.NgayXuat).ToList();
                }
                if (!string.IsNullOrEmpty(swhere))
                {
                    if (swhere == " and Year(pxs.NgayXuat) = " + DateTime.Today.Year + " and Month(pxs.NgayXuat) = " + DateTime.Today.Month)
                    {
                        dspx = dspx.Where(phieuxuat => phieuxuat.NgayXuat.Value.Year == DateTime.Today.Year || phieuxuat.NgayXuat.Value.Month == DateTime.Today.Month).ToList();
                    }
                    else
                    {
                        dspx = dspx.Where(phieuxuat => phieuxuat.MaPhieuXuat.Contains(swhere) || phieuxuat.NhanVien1.TenNhanVien.Contains(swhere) || phieuxuat.NhanVien.Contains(swhere) || phieuxuat.KhachHang.Contains(swhere) || phieuxuat.KhachHang1.TenKhachHang.Contains(swhere)).ToList();
                    }
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("MaPhieuXuat");
                dt.Columns.Add("NhanVien");
                dt.Columns.Add("TenNhanVien");
                dt.Columns.Add("KhachHang");
                dt.Columns.Add("TenKhachHang");
                dt.Columns.Add("NgayXuat");
                dt.Columns.Add("HoaDon");
                dt.Columns.Add("DiaChiNhan");
                dt.Columns.Add("TongTien");
                if (dspx.Count > 0)
                {
                    foreach (Model.PhieuXuat px in dspx)
                    {
                        DataRow row = dt.NewRow();
                        row["MaPhieuXuat"] = px.MaPhieuXuat;
                        row["NhanVien"] = px.NhanVien;
                        row["TenNhanVien"] = px.NhanVien1.TenNhanVien;
                        row["KhachHang"] = px.KhachHang;
                        row["TenKhachHang"] = px.KhachHang1.TenKhachHang;
                        row["NgayXuat"] = px.NgayXuat;
                        row["HoaDon"] = px.HoaDon;
                        row["DiaChiNhan"] = px.DiaChiNhan;
                        row["TongTien"] = px.TongTien;
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
    }
}
