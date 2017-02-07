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
    public class PhieuThuDAL
    {
        QuanLiBanHang_DAL.Model.QuanLiBanHangEntities db = new QuanLiBanHang_DAL.Model.QuanLiBanHangEntities();
        //Lấy danh sách phiếu thu
        public DataSet GetPhieuThu(PhieuThu inp,string swhere)
        {
            try
            {
                List<Model.PhieuThuTien> dspt = (from pt in db.PhieuThuTiens
                                                 select pt).ToList();
                if (!string.IsNullOrEmpty(inp.MaPhieuThu))
                {
                    dspt = dspt.Where(phieuthu => phieuthu.MaPhieuThu == inp.MaPhieuThu).ToList();
                }
                if (!string.IsNullOrEmpty(inp.NhanVien))
                {
                    dspt = dspt.Where(phieuthu => phieuthu.NhanVien == inp.NhanVien).ToList();
                }
                if (!string.IsNullOrEmpty(inp.KhachHang))
                {
                    dspt = dspt.Where(phieuthu => phieuthu.KhachHang == inp.KhachHang).ToList();
                }
                if (inp.NgayThu.Year != 1)
                {
                    dspt = dspt.Where(phieuthu => phieuthu.NgayThu == inp.NgayThu).ToList();
                }
                if (!string.IsNullOrEmpty(swhere))
                {
                    if (swhere == " and Year(NgayThu) = " + DateTime.Today.Year + " and Month(NgayThu) = " + DateTime.Today.Month)
                    {
                        dspt = dspt.Where(phieuthu => phieuthu.NgayThu.Value.Year == DateTime.Today.Year || phieuthu.NgayThu.Value.Month == DateTime.Today.Month).ToList();
                    }
                    else
                    {
                        dspt = dspt.Where(phieuthu => phieuthu.MaPhieuThu.Contains(swhere) || phieuthu.NhanVien1.TenNhanVien.Contains(swhere) || phieuthu.NhanVien.Contains(swhere) || phieuthu.KhachHang.Contains(swhere) || phieuthu.KhachHang1.TenKhachHang.Contains(swhere)).ToList();
                    }
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("MaPhieuThu");
                dt.Columns.Add("NhanVien");
                dt.Columns.Add("TenNhanVien");
                dt.Columns.Add("KhachHang");
                dt.Columns.Add("TenKhachHang");
                dt.Columns.Add("NgayThu");
                dt.Columns.Add("SoTienThu");
                if (dspt.Count > 0)
                {
                    foreach (Model.PhieuThuTien pt in dspt)
                    {
                        DataRow row = dt.NewRow();
                        row["MaPhieuThu"] = pt.MaPhieuThu;
                        row["NhanVien"] = pt.NhanVien;
                        row["TenNhanVien"] = pt.NhanVien1.TenNhanVien;
                        row["KhachHang"] = pt.KhachHang;
                        row["TenKhachHang"] = pt.KhachHang1.TenKhachHang;
                        row["NgayThu"] = pt.NgayThu;
                        row["SoTienThu"] = pt.SoTienThu;
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
