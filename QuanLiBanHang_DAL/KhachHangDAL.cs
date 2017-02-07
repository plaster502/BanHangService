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
    public class KhachHangDAL
    {
        QuanLiBanHang_DAL.Model.QuanLiBanHangEntities db = new QuanLiBanHang_DAL.Model.QuanLiBanHangEntities();
        //Lấy danh sách khách hàng
        public DataSet GetKhachHang(KhachHang inp,string swhere)
        {
            try
            {
                List<QuanLiBanHang_DAL.Model.KhachHang> dskhach = (from kh in db.KhachHangs
                                                                   select kh).ToList();
                if (!string.IsNullOrEmpty(inp.MaKhachHang))
                {
                    dskhach = dskhach.Where(khach => khach.MaKhachHang == inp.MaKhachHang).ToList();
                }
                if (!string.IsNullOrEmpty(inp.TenKhachHang))
                {
                    dskhach = dskhach.Where(khach => khach.TenKhachHang == inp.TenKhachHang).ToList();
                }
                if (!string.IsNullOrEmpty(inp.DiaChi))
                {
                    dskhach = dskhach.Where(khach => khach.DiaChi == inp.DiaChi).ToList();
                }
                if (!string.IsNullOrEmpty(inp.SoDienThoai))
                {
                    dskhach = dskhach.Where(khach => khach.SoDienThoai == inp.SoDienThoai).ToList();
                }
                if (!string.IsNullOrEmpty(inp.Email))
                {
                    dskhach = dskhach.Where(khach => khach.Email == inp.Email).ToList();
                }
                if (inp.SoNo != 0)
                {
                    dskhach = dskhach.Where(khach => khach.SoNo == inp.SoNo).ToList();
                }
                if (!string.IsNullOrEmpty(swhere))
                {
                    switch (swhere)
                    {
                        case " and SoNo > 0":
                            dskhach = dskhach.Where(khach => khach.SoNo > 0 ).ToList();
                            break;
                        default:
                            dskhach = dskhach.Where(khach => khach.MaKhachHang.Contains(swhere) || khach.TenKhachHang.Contains(swhere) || khach.DiaChi.Contains(swhere) || khach.SoDienThoai.Contains(swhere) || khach.Email.Contains(swhere)).ToList();
                            break;
                    }
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("MaKhachHang");
                dt.Columns.Add("TenKhachHang");
                dt.Columns.Add("DiaChi");
                dt.Columns.Add("SoDienThoai");
                dt.Columns.Add("Email");
                dt.Columns.Add("SoNo");
                if (dskhach.Count > 0)
                {
                    foreach (Model.KhachHang ks in dskhach)
                    {
                        DataRow row = dt.NewRow();
                        row["MaKhachHang"] = ks.MaKhachHang;
                        row["TenKhachHang"] = ks.TenKhachHang;
                        row["DiaChi"] = ks.DiaChi;
                        row["SoDienThoai"] = ks.SoDienThoai;
                        row["Email"] = ks.Email;
                        row["SoNo"] = ks.SoNo;
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
