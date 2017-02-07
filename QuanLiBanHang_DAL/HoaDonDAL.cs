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
    public class HoaDonDAL
    {
        QuanLiBanHang_DAL.Model.QuanLiBanHangEntities db = new QuanLiBanHang_DAL.Model.QuanLiBanHangEntities();
        //Lấy danh sách hoá đơn
        public DataSet GetHoaDon(QuanLiBanHang_BDO.HoaDon inp, string swhere)
        {
            try
            {
                List<Model.HoaDon> dshd = (from hd in db.HoaDons
                                           select hd).ToList();
                if (!string.IsNullOrEmpty(inp.MaHoaDon))
                {
                    dshd = dshd.Where(hoadon => hoadon.MaHoaDon == inp.MaHoaDon).ToList();
                }
                if (!string.IsNullOrEmpty(inp.KhachHang))
                {
                    dshd = dshd.Where(hoadon => hoadon.KhachHang == inp.KhachHang).ToList();
                }
                if (!string.IsNullOrEmpty(inp.NhanVien))
                {
                    dshd = dshd.Where(hoadon => hoadon.NhanVien == inp.NhanVien).ToList();
                }
                if (inp.NgayXuat.Year != 1)
                {
                    dshd = dshd.Where(hoadon => hoadon.NgayXuat == inp.NgayXuat).ToList();
                }
                if (!string.IsNullOrEmpty(swhere))
                {
                    if (swhere == " and Year(NgayXuat) = " + DateTime.Today.Year + " and Month(NgayXuat) = " + DateTime.Today.Month)
                    {
                        dshd = dshd.Where(hoadon => hoadon.NgayXuat.Value.Year == DateTime.Today.Year || hoadon.NgayXuat.Value.Month == DateTime.Today.Month).ToList();
                    }
                    else
                    {
                        dshd = dshd.Where(hoadon => hoadon.MaHoaDon.Contains(swhere) || hoadon.NhanVien1.TenNhanVien.Contains(swhere) || hoadon.NhanVien.Contains(swhere) || hoadon.KhachHang.Contains(swhere) || hoadon.KhachHang1.TenKhachHang.Contains(swhere)).ToList();
                    }
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("MaHoaDon");
                dt.Columns.Add("NhanVien");
                dt.Columns.Add("TenNhanVien");
                dt.Columns.Add("KhachHang");
                dt.Columns.Add("TenKhachHang");
                dt.Columns.Add("NgayXuat");
                dt.Columns.Add("TongTien");
                dt.Columns.Add("DonHang");
                dt.Columns.Add("DaThanhToan");
                dt.Columns.Add("ConLai");
                if (dshd.Count > 0)
                {
                    foreach (Model.HoaDon hd in dshd)
                    {
                        DataRow row = dt.NewRow();
                        row["MaHoaDon"] = hd.MaHoaDon;
                        row["NhanVien"] = hd.NhanVien;
                        row["TenNhanVien"] = hd.NhanVien1.TenNhanVien;
                        row["KhachHang"] = hd.KhachHang;
                        row["TenKhachHang"] = hd.KhachHang1.TenKhachHang;
                        row["NgayXuat"] = hd.NgayXuat;
                        row["TongTien"] = hd.TongTien;
                        row["DonHang"] = hd.DonHang;
                        row["DaThanhToan"] = hd.DaThanhToan;
                        row["ConLai"] = hd.ConLai;
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
        //Lấy chi tiết hoá đơn
        public List<HoaDonCT> LoadChiTiet(string mahd)
        {
            List<Model.HoaDon_CT> dsct = (from dhct in db.HoaDon_CT
                                          where dhct.MaHoaDon == mahd
                                          select dhct).ToList();
            List<HoaDonCT> kq = new List<HoaDonCT>();
            foreach (Model.HoaDon_CT ct in dsct)
            {
                HoaDonCT kqct = new HoaDonCT();
                kqct.MaHoaDon = ct.MaHoaDon;
                kqct.MaSanPham = ct.MaSanPham;
                kqct.DonGia = ct.DonGia.Value;
                kqct.SoLuong = ct.SoLuong;
                kq.Add(kqct);
            }
            return kq;
        }

        //Thêm hoá đơn
        public bool Insert(HoaDon inp)
        {
            try
            {
                Model.HoaDon newhd = new Model.HoaDon();
                newhd.MaHoaDon = inp.MaHoaDon;
                newhd.NhanVien = inp.NhanVien;
                newhd.KhachHang = inp.KhachHang;
                newhd.NgayXuat = inp.NgayXuat;
                if (string.IsNullOrEmpty(inp.DonDatHang))
                    newhd.DonDatHang = null;
                else
                    newhd.DonHang = inp.DonDatHang;
                newhd.TongTien = inp.TongTien;
                newhd.DaThanhToan = inp.DaThanhToan;
                newhd.ConLai = inp.ConLai;
                db.HoaDons.Add(newhd);
                int kq = db.SaveChanges();
                if (kq > 0)
                {
                    foreach (HoaDonCT ct in inp.DSChiTiet)
                    {
                        //Thêm vào chi tiết hoá đơn
                        Model.HoaDon_CT newct = new Model.HoaDon_CT();
                        newct.MaHoaDon = ct.MaHoaDon;
                        newct.MaSanPham = ct.MaSanPham;
                        newct.SoLuong = ct.SoLuong;
                        newct.DonGia = ct.DonGia;
                        db.HoaDon_CT.Add(newct);
                        db.SaveChanges();
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Sửa hoá đơn
        public bool Update(HoaDon inp)
        {
            try
            {
                IEnumerable<Model.HoaDon> dshd = from hd in db.HoaDons
                                                 where hd.MaHoaDon == inp.MaHoaDon
                                                 select hd;
                Model.HoaDon hoadon = dshd.ElementAtOrDefault(0);
                if (hoadon != null)
                {
                    hoadon.NhanVien = inp.NhanVien;
                    hoadon.KhachHang = inp.KhachHang;
                    hoadon.DonHang = inp.DonDatHang;
                    hoadon.NgayXuat = inp.NgayXuat;
                    hoadon.TongTien = inp.TongTien;
                    hoadon.DaThanhToan = inp.DaThanhToan;
                    hoadon.ConLai = inp.ConLai;
                    db.SaveChanges();
                    //Xoá chi tiết hoá đơn cũ
                    IEnumerable<Model.HoaDon_CT> dsctc = from ctc in db.HoaDon_CT
                                                         where ctc.MaHoaDon == inp.MaHoaDon
                                                         select ctc;
                    if (dsctc.Count() > 0)
                    {
                        foreach (Model.HoaDon_CT ctc in dsctc)
                        {
                            //xoá chi tiết hoá đơn
                            db.HoaDon_CT.Remove(ctc);
                        }
                        db.SaveChanges();
                    }
                    //Nhập lại chi tiết hoá đơn
                    foreach (HoaDonCT ct in inp.DSChiTiet)
                    {
                        Model.HoaDon_CT newct = new Model.HoaDon_CT();
                        newct.MaHoaDon = ct.MaHoaDon;
                        newct.MaSanPham = ct.MaSanPham;
                        newct.SoLuong = ct.SoLuong;
                        newct.DonGia = ct.DonGia;
                        db.HoaDon_CT.Add(newct);
                        db.SaveChanges();
                    }
                    return true;
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
        //Xoá hoá đơn
        public bool Delete(string mahd)
        {
            try
            {
                IEnumerable<Model.HoaDon_CT> dsct = from ct in db.HoaDon_CT
                                                        where ct.MaHoaDon == mahd
                                                        select ct;
                if (dsct.Count() > 0)
                {
                    foreach (Model.HoaDon_CT ct in dsct)//xoá chi tiết
                    {
                        //xoá chi tiết hoá đơn
                        db.HoaDon_CT.Remove(ct);
                    }
                    int kq = db.SaveChanges();
                    if (kq > 0)//xoá chi tiết hoá đơn xong mới xoá hoá đơn
                    {
                        IEnumerable<Model.HoaDon> dshd = from hd in db.HoaDons
                                                             where hd.MaHoaDon == mahd
                                                             select hd;
                        if (dshd.Count() > 0)
                        {
                            foreach (Model.HoaDon hd in dshd)//xoá hoá đơn
                            {
                                db.HoaDons.Remove(hd);
                            }
                            kq = db.SaveChanges();
                        }
                        return true;
                    }
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

        //Tạo mã hoá đơn mới
        public string GetNewID(int year, int month)
        {
            try
            {
                string MaThang = "HD" + year.ToString("0000") + month.ToString("00");
                List<Model.HoaDon> dshd = (from hd in db.HoaDons
                                               where hd.MaHoaDon.Contains(MaThang)
                                               select hd).ToList();
                if (dshd.Count() > 0)
                {
                    string mangay = dshd.Max(x => x.MaHoaDon);
                    int sophieu = Convert.ToInt32(mangay.Substring(8, 6)) + 1;
                    return "HD" + year.ToString("0000") + month.ToString("00") + sophieu.ToString("000000");
                }
                else
                {
                    return "HD" + year.ToString("0000") + month.ToString("00") + "000001";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
