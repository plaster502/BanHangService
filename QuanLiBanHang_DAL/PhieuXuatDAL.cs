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

        //Lấy chi tiết phiếu
        public List<PhieuXuatCT> LoadChiTiet(string mapx)
        {
            List<Model.PhieuXuat_CT> dsct = (from pxct in db.PhieuXuat_CT
                                             where pxct.MaPhieuXuat == mapx
                                             select pxct).ToList();
            List<PhieuXuatCT> kq = new List<PhieuXuatCT>();
            foreach (Model.PhieuXuat_CT ct in dsct)
            {
                PhieuXuatCT kqct = new PhieuXuatCT();
                kqct.MaPhieuXuat = ct.MaPhieuXuat;
                kqct.MaSanPham = ct.MaSanPham;
                kqct.DonGia = ct.DonGia.Value;
                kqct.SoLuongThuc = ct.SoLuongThucXuat;
                kqct.SoLuongYeuCau = ct.SoLuongYeuCau;
                kq.Add(kqct);
            }
            return kq;
        }

        //Thêm phiếu xuất
        public bool Insert(PhieuXuat inp)
        {
            try
            {
                Model.PhieuXuat newpx = new Model.PhieuXuat();
                newpx.MaPhieuXuat = inp.MaPhieuXuat;
                newpx.NgayXuat = inp.NgayXuat;
                newpx.NhanVien = inp.MaNhanVien;
                newpx.KhachHang = inp.MaKhachHang;
                newpx.DiaChiNhan = inp.DiaChiGiaoHang;
                newpx.HoaDon = inp.MaHoaDon;
                newpx.TongTien = inp.TongTien;
                db.PhieuXuats.Add(newpx);
                int kq = db.SaveChanges();
                if (kq > 0)
                {
                    foreach (PhieuXuatCT ct in inp.DSChiTiet)
                    {
                        //Thêm vào chi tiết phiếu xuất
                        Model.PhieuXuat_CT newct = new Model.PhieuXuat_CT();
                        newct.MaPhieuXuat = ct.MaPhieuXuat;
                        newct.MaSanPham = ct.MaSanPham;
                        newct.SoLuongYeuCau = ct.SoLuongYeuCau;
                        newct.SoLuongThucXuat = ct.SoLuongThuc;
                        newct.DonGia = ct.DonGia;
                        db.PhieuXuat_CT.Add(newct);
                        db.SaveChanges();
                        //Cộng vào số lượng tồn
                        IEnumerable<Model.SanPham> cnsp = from sp in db.SanPhams
                                                          where sp.MaSanPham == newct.MaSanPham
                                                          select sp;
                        Model.SanPham sanpham = cnsp.ElementAtOrDefault(0);
                        sanpham.SoLuongTon = sanpham.SoLuongTon - ct.SoLuongThuc;
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
        //Sửa phiếu xuất
        public bool Update(PhieuXuat inp)
        {
            try
            {
                IEnumerable<Model.PhieuXuat> dspx = from px in db.PhieuXuats
                                                    where px.MaPhieuXuat == inp.MaPhieuXuat
                                                    select px;
                Model.PhieuXuat phieuxuat = dspx.ElementAtOrDefault(0);
                if (phieuxuat != null)
                {
                    phieuxuat.NhanVien = inp.MaNhanVien;
                    phieuxuat.KhachHang = inp.MaKhachHang;
                    phieuxuat.NgayXuat = inp.NgayXuat;
                    phieuxuat.DiaChiNhan = inp.DiaChiGiaoHang;
                    phieuxuat.HoaDon = inp.MaHoaDon;
                    phieuxuat.TongTien = inp.TongTien;
                    db.SaveChanges();
                    //Xoá chi tiết phiếu xuất cũ
                    IEnumerable<Model.PhieuXuat_CT> dsctc = from ctc in db.PhieuXuat_CT
                                                            where ctc.MaPhieuXuat == inp.MaPhieuXuat
                                                            select ctc;
                    if (dsctc.Count() > 0)
                    {
                        foreach (Model.PhieuXuat_CT ctc in dsctc)
                        {
                            //cộng số lượng tồn
                            Model.QuanLiBanHangEntities db2 = new Model.QuanLiBanHangEntities();
                            IEnumerable<Model.SanPham> cnsp = from sp in db2.SanPhams
                                                              where sp.MaSanPham == ctc.MaSanPham
                                                              select sp;
                            Model.SanPham sanpham = cnsp.ElementAtOrDefault(0);
                            sanpham.SoLuongTon = sanpham.SoLuongTon + ctc.SoLuongThucXuat;
                            db2.SaveChanges();
                            //xoá chi tiết phiếu
                            db.PhieuXuat_CT.Remove(ctc);
                        }
                        db.SaveChanges();
                    }
                    //Nhập lại chi tiết phiếu
                    foreach (PhieuXuatCT ct in inp.DSChiTiet)
                    {
                        Model.PhieuXuat_CT newct = new Model.PhieuXuat_CT();
                        newct.MaPhieuXuat = ct.MaPhieuXuat;
                        newct.MaSanPham = ct.MaSanPham;
                        newct.SoLuongYeuCau = ct.SoLuongYeuCau;
                        newct.SoLuongThucXuat = ct.SoLuongThuc;
                        newct.DonGia = ct.DonGia;
                        db.PhieuXuat_CT.Add(newct);
                        db.SaveChanges();
                        //Trừ vào số lượng tồn
                        IEnumerable<Model.SanPham> cnsp = from sp in db.SanPhams
                                                          where sp.MaSanPham == newct.MaSanPham
                                                          select sp;
                        Model.SanPham sanpham = cnsp.ElementAtOrDefault(0);
                        sanpham.SoLuongTon = sanpham.SoLuongTon - ct.SoLuongThuc;
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
        //Xoá phiếu xuất
        public bool Delete(string mapx)
        {
            try
            {
                IEnumerable<Model.PhieuXuat_CT> dsct = from ct in db.PhieuXuat_CT
                                                       where ct.MaPhieuXuat == mapx
                                                       select ct;
                if (dsct.Count() > 0)
                {
                    foreach (Model.PhieuXuat_CT ct in dsct)//xoá chi tiết
                    {
                        //cộng số lượng tồn
                        IEnumerable<Model.SanPham> cnsp = from sp in db.SanPhams
                                                          where sp.MaSanPham == ct.MaSanPham
                                                          select sp;
                        Model.SanPham sanpham = cnsp.ElementAtOrDefault(0);
                        sanpham.SoLuongTon = sanpham.SoLuongTon + ct.SoLuongThucXuat;
                        db.SaveChanges();
                        //xoá chi tiết phiếu
                        db.PhieuXuat_CT.Remove(ct);
                    }
                    int kq = db.SaveChanges();
                    if (kq > 0)
                    {
                        IEnumerable<Model.PhieuXuat> dspx = from px in db.PhieuXuats
                                                            where px.MaPhieuXuat == mapx
                                                            select px;
                        if (dspx.Count() > 0)
                        {
                            foreach (Model.PhieuXuat px in dspx)//xoá phiếu
                            {
                                db.PhieuXuats.Remove(px);
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

        //Tạo mã phiếu mới
        public string GetNewID(int year, int month)
        {
            try
            {
                string MapxThang = "PX" + year.ToString("0000") + month.ToString("00");
                List<Model.PhieuXuat> dspx = (from px in db.PhieuXuats
                                              where px.MaPhieuXuat.Contains(MapxThang)
                                              select px).ToList();
                if (dspx.Count() > 0)
                {
                    string mangay = dspx.Max(x => x.MaPhieuXuat);
                    int sophieu = Convert.ToInt32(mangay.Substring(8, 6)) + 1;
                    return "PX" + year.ToString("0000") + month.ToString("00") + sophieu.ToString("000000");
                }
                else
                {
                    return "PX" + year.ToString("0000") + month.ToString("00") + "000001";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
