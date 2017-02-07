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
    public class DonDatHangDAL
    {
        QuanLiBanHang_DAL.Model.QuanLiBanHangEntities db = new QuanLiBanHang_DAL.Model.QuanLiBanHangEntities();
        //Lấy danh sách đơn hàng
        public DataSet GetDonHang(DonDatHang inp, string swhere)
        {
            try
            {
                List<Model.DonDatHang> dsdh = (from ddh in db.DonDatHangs
                                               select ddh).ToList();
                if (!string.IsNullOrEmpty(inp.MaDonHang))
                {
                    dsdh = dsdh.Where(donhang => donhang.MaDonHang == inp.MaDonHang).ToList();
                }
                if (!string.IsNullOrEmpty(inp.MaNhanVien))
                {
                    dsdh = dsdh.Where(donhang => donhang.NhanVien == inp.MaNhanVien).ToList();
                }
                if (!string.IsNullOrEmpty(inp.MaKhachHang))
                {
                    dsdh = dsdh.Where(donhang => donhang.KhachHang == inp.MaKhachHang).ToList();
                }
                if (inp.NgayTao.Year != 1)
                {
                    dsdh = dsdh.Where(donhang => donhang.NgayDat == inp.NgayTao).ToList();
                }
                if (!string.IsNullOrEmpty(swhere))
                {
                    dsdh = dsdh.Where(donhang => donhang.MaDonHang.Contains(swhere) || donhang.NhanVien1.TenNhanVien.Contains(swhere) || donhang.NhanVien.Contains(swhere) || donhang.KhachHang.Contains(swhere) || donhang.KhachHang1.TenKhachHang.Contains(swhere)).ToList();
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("MaDonHang");
                dt.Columns.Add("NhanVien");
                dt.Columns.Add("TenNhanVien");
                dt.Columns.Add("KhachHang");
                dt.Columns.Add("TenKhachHang");
                dt.Columns.Add("NgayLap");
                dt.Columns.Add("TongTien");
                if (dsdh.Count > 0)
                {
                    foreach (Model.DonDatHang dh in dsdh)
                    {
                        DataRow row = dt.NewRow();
                        row["MaDonHang"] = dh.MaDonHang;
                        row["NhanVien"] = dh.NhanVien;
                        row["TenNhanVien"] = dh.NhanVien1.TenNhanVien;
                        row["KhachHang"] = dh.KhachHang;
                        row["TenKhachHang"] = dh.KhachHang1.TenKhachHang;
                        row["NgayLap"] = dh.NgayDat;
                        row["TongTien"] = dh.TongTien;
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
        //Lấy chi tiết đơn hàng
        public List<DonDatHangCT> LoadChiTiet(string madh)
        {
            List<Model.DonDatHang_CT> dsct = (from dhct in db.DonDatHang_CT
                                              where dhct.MaDonHang == madh
                                              select dhct).ToList();
            List<DonDatHangCT> kq = new List<DonDatHangCT>();
            foreach (Model.DonDatHang_CT ct in dsct)
            {
                DonDatHangCT kqct = new DonDatHangCT();
                kqct.MaDonDatHang = ct.MaDonHang;
                kqct.MaSanPham = ct.MaSanPham;
                kqct.DonGia = ct.DonGia.Value;
                kqct.SoLuong = ct.SoLuong.Value;
                kq.Add(kqct);
            }
            return kq;
        }

        //Thêm đơn hàng
        public bool Insert(DonDatHang inp)
        {
            try
            {
                Model.DonDatHang newdh = new Model.DonDatHang();
                newdh.MaDonHang = inp.MaDonHang;
                newdh.NhanVien = inp.MaNhanVien;
                newdh.KhachHang = inp.MaKhachHang;
                newdh.NgayDat = inp.NgayTao;
                newdh.TongTien = inp.TongTien;
                db.DonDatHangs.Add(newdh);
                int kq = db.SaveChanges();
                if (kq > 0)
                {
                    foreach (DonDatHangCT ct in inp.DSChiTiet)
                    {
                        //Thêm vào chi tiết phiếu nhập
                        Model.DonDatHang_CT newct = new Model.DonDatHang_CT();
                        newct.MaDonHang = ct.MaDonDatHang;
                        newct.MaSanPham = ct.MaSanPham;
                        newct.SoLuong = ct.SoLuong;
                        newct.DonGia = ct.DonGia;
                        db.DonDatHang_CT.Add(newct);
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
        //Sửa đơn hàng
        public bool Update(DonDatHang inp)
        {
            try
            {
                IEnumerable<Model.DonDatHang> dsdh = from dh in db.DonDatHangs
                                                 where dh.MaDonHang == inp.MaDonHang
                                                 select dh;
                Model.DonDatHang donhang = dsdh.ElementAtOrDefault(0);
                if (donhang != null)
                {
                    donhang.NhanVien = inp.MaNhanVien;
                    donhang.KhachHang = inp.MaKhachHang;
                    donhang.NgayDat = inp.NgayTao;
                    donhang.TongTien = inp.TongTien;
                    db.SaveChanges();
                    //Xoá chi tiết đơn hàng cũ
                    IEnumerable<Model.DonDatHang_CT> dsctc = from ctc in db.DonDatHang_CT
                                                             where ctc.MaDonHang == inp.MaDonHang
                                                             select ctc;
                    if (dsctc.Count() > 0)
                    {
                        foreach (Model.DonDatHang_CT ctc in dsctc)
                        {
                            //xoá chi tiết phiếu
                            db.DonDatHang_CT.Remove(ctc);
                        }
                        db.SaveChanges();
                    }
                    //Nhập lại chi tiết báo giá
                    foreach (DonDatHangCT ct in inp.DSChiTiet)
                    {
                        Model.DonDatHang_CT newct = new Model.DonDatHang_CT();
                        newct.MaDonHang = ct.MaDonDatHang;
                        newct.MaSanPham = ct.MaSanPham;
                        newct.SoLuong = ct.SoLuong;
                        newct.DonGia = ct.DonGia;
                        db.DonDatHang_CT.Add(newct);
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
        //Xoá đơn hàng
        public bool Delete(string madh)
        {
            try
            {
                IEnumerable<Model.DonDatHang_CT> dsct = from ct in db.DonDatHang_CT
                                                        where ct.MaDonHang == madh
                                                        select ct;
                if (dsct.Count() > 0)
                {
                    foreach (Model.DonDatHang_CT ct in dsct)//xoá chi tiết
                    {
                        //xoá chi tiết đơn hàng
                        db.DonDatHang_CT.Remove(ct);
                    }
                    int kq = db.SaveChanges();
                    if (kq > 0)//xoá chi tiết đơn hàng xong mới xoá đơn hàng
                    {
                        IEnumerable<Model.DonDatHang> dsdh = from dh in db.DonDatHangs
                                                             where dh.MaDonHang == madh
                                                             select dh;
                        if (dsdh.Count() > 0)
                        {
                            foreach (Model.DonDatHang dh in dsdh)//xoá đơn
                            {
                                db.DonDatHangs.Remove(dh);
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

        //Tạo mã đơn hàng mới
        public string GetNewID(int year, int month)
        {
            try
            {
                string MaThang = "DH" + year.ToString("0000") + month.ToString("00");
                List<Model.DonDatHang> dsdh = (from dh in db.DonDatHangs
                                               where dh.MaDonHang.Contains(MaThang)
                                               select dh).ToList();
                if (dsdh.Count() > 0)
                {
                    string mangay = dsdh.Max(x => x.MaDonHang);
                    int sophieu = Convert.ToInt32(mangay.Substring(8, 6)) + 1;
                    return "DH" + year.ToString("0000") + month.ToString("00") + sophieu.ToString("000000");
                }
                else
                {
                    return "DH" + year.ToString("0000") + month.ToString("00") + "000001";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
