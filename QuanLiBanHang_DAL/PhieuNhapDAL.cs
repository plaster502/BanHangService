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
    public class PhieuNhapDAL
    {
        QuanLiBanHang_DAL.Model.QuanLiBanHangEntities db = new QuanLiBanHang_DAL.Model.QuanLiBanHangEntities();
        //Lấy danh sách phiếu nhập
        public DataSet GetPhieuNhap(PhieuNhap inp,string swhere)
        {
            try
            {
                List<Model.PhieuNhap> dspn = (from pn in db.PhieuNhaps
                                                 select pn).ToList();
                if (!string.IsNullOrEmpty(inp.MaPhieuNhap))
                {
                    dspn = dspn.Where(phieunhap => phieunhap.MaPhieuNhap == inp.MaPhieuNhap).ToList();
                }
                if (!string.IsNullOrEmpty(inp.MaNhanVien))
                {
                    dspn = dspn.Where(phieunhap => phieunhap.NhanVien == inp.MaNhanVien).ToList();
                }
                if (inp.NgayNhap.Year != 1)
                {
                    dspn = dspn.Where(phieunhap => phieunhap.NgayNhap == inp.NgayNhap).ToList();
                }
                if (!string.IsNullOrEmpty(swhere))
                {
                    if (swhere == " and Year(pns.NgayNhap) = " + DateTime.Today.Year + " and Month(pns.NgayNhap) = " + DateTime.Today.Month)
                    {
                        dspn = dspn.Where(phieunhap => phieunhap.NgayNhap.Value.Year == DateTime.Today.Year || phieunhap.NgayNhap.Value.Month == DateTime.Today.Month).ToList();
                    }
                    else
                    {
                        dspn = dspn.Where(phieunhap => phieunhap.MaPhieuNhap.Contains(swhere) || phieunhap.NhanVien1.TenNhanVien.Contains(swhere) || phieunhap.NhanVien.Contains(swhere)).ToList();
                    }
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("MaPhieuNhap");
                dt.Columns.Add("NhanVien");
                dt.Columns.Add("TenNhanVien");
                dt.Columns.Add("NgayNhap");
                dt.Columns.Add("TongTien");
                if (dspn.Count > 0)
                {
                    foreach (Model.PhieuNhap pn in dspn)
                    {
                        DataRow row = dt.NewRow();
                        row["MaPhieuNhap"] = pn.MaPhieuNhap;
                        row["NhanVien"] = pn.NhanVien;
                        row["TenNhanVien"] = pn.NhanVien1.TenNhanVien;
                        row["NgayNhap"] = pn.NgayNhap;
                        row["TongTien"] = pn.TongTien;
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
        public List<PhieuNhapCT> LoadChiTiet(string mapn)
        {
            List<Model.PhieuNhap_CT> dsct = (from pnct in db.PhieuNhap_CT
                                             where pnct.MaPhieuNhap == mapn
                                             select pnct).ToList();
            List<PhieuNhapCT> kq = new List<PhieuNhapCT>();
            foreach (Model.PhieuNhap_CT ct in dsct)
            {
                PhieuNhapCT kqct = new PhieuNhapCT();
                kqct.MaPhieuNhap = ct.MaPhieuNhap;
                kqct.MaSanPham = ct.MaSanPham;
                kqct.DonGia = ct.DonGia.Value;
                kqct.SoLuong = ct.SoLuong;
                kq.Add(kqct);
            }
            return kq;
        }

        //Thêm phiếu nhập
        public bool Insert(PhieuNhap inp)
        {
            try
            {
                Model.PhieuNhap newpn = new Model.PhieuNhap();
                newpn.MaPhieuNhap = inp.MaPhieuNhap;
                newpn.NhanVien = inp.MaNhanVien;
                newpn.NgayNhap = inp.NgayNhap;
                newpn.TongTien = inp.TongTien;
                db.PhieuNhaps.Add(newpn);
                int kq = db.SaveChanges();
                if (kq > 0)
                {
                    foreach (PhieuNhapCT ct in inp.DSChiTiet)
                    {
                        //Thêm vào chi tiết phiếu nhập
                        Model.PhieuNhap_CT newct = new Model.PhieuNhap_CT();
                        newct.MaPhieuNhap = ct.MaPhieuNhap;
                        newct.MaSanPham = ct.MaSanPham;
                        newct.SoLuong = ct.SoLuong;
                        newct.DonGia = ct.DonGia;
                        db.PhieuNhap_CT.Add(newct);
                        db.SaveChanges();
                        //Cộng vào số lượng tồn
                        IEnumerable<Model.SanPham> cnsp = from sp in db.SanPhams
                                                          where sp.MaSanPham == newct.MaSanPham
                                                          select sp;
                        Model.SanPham sanpham = cnsp.ElementAtOrDefault(0);
                        sanpham.SoLuongTon = sanpham.SoLuongTon + ct.SoLuong;
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
        //Sửa phiếu nhập
        public bool Update(PhieuNhap inp)
        {
            try
            {
                IEnumerable<Model.PhieuNhap> dspn = from pn in db.PhieuNhaps
                                                    where pn.MaPhieuNhap == inp.MaPhieuNhap
                                                    select pn;
                Model.PhieuNhap phieunhap = dspn.ElementAtOrDefault(0);
                if (phieunhap != null)
                {
                    phieunhap.NhanVien = inp.MaNhanVien;
                    phieunhap.NgayNhap = inp.NgayNhap;
                    phieunhap.TongTien = inp.TongTien;
                    db.SaveChanges();
                    //Xoá chi tiết phiếu nhập cũ
                    IEnumerable<Model.PhieuNhap_CT> dsctc = from ctc in db.PhieuNhap_CT
                                                            where ctc.MaPhieuNhap == inp.MaPhieuNhap
                                                            select ctc;
                    if (dsctc.Count() > 0)
                    {
                        foreach (Model.PhieuNhap_CT ctc in dsctc)
                        {
                            //trừ số lượng tồn
                            Model.QuanLiBanHangEntities db2 = new Model.QuanLiBanHangEntities();
                            IEnumerable<Model.SanPham> cnsp = from sp in db2.SanPhams
                                                                where sp.MaSanPham == ctc.MaSanPham
                                                                select sp;
                            Model.SanPham sanpham = cnsp.ElementAtOrDefault(0);
                            sanpham.SoLuongTon = sanpham.SoLuongTon - ctc.SoLuong;
                            db2.SaveChanges();
                            //xoá chi tiết phiếu
                            db.PhieuNhap_CT.Remove(ctc);
                        }
                        db.SaveChanges();
                    }
                    //Nhập lại chi tiết phiếu
                    foreach (PhieuNhapCT ct in inp.DSChiTiet)
                    {
                        Model.PhieuNhap_CT newct = new Model.PhieuNhap_CT();
                        newct.MaPhieuNhap = ct.MaPhieuNhap;
                        newct.MaSanPham = ct.MaSanPham;
                        newct.SoLuong = ct.SoLuong;
                        newct.DonGia = ct.DonGia;
                        db.PhieuNhap_CT.Add(newct);
                        db.SaveChanges();
                        //Cộng vào số lượng tồn
                        IEnumerable<Model.SanPham> cnsp = from sp in db.SanPhams
                                                            where sp.MaSanPham == newct.MaSanPham
                                                            select sp;
                        Model.SanPham sanpham = cnsp.ElementAtOrDefault(0);
                        sanpham.SoLuongTon = sanpham.SoLuongTon + ct.SoLuong;
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
        //Xoá phiếu nhập
        public bool Delete(string mapn)
        {
            try
            {
                IEnumerable<Model.PhieuNhap_CT> dsct = from ct in db.PhieuNhap_CT
                                                  where ct.MaPhieuNhap == mapn
                                                  select ct;
                if (dsct.Count() > 0)
                {
                    foreach (Model.PhieuNhap_CT ct in dsct)//xoá chi tiết
                    {
                        //trừ số lượng tồn
                        IEnumerable<Model.SanPham> cnsp = from sp in db.SanPhams
                                                          where sp.MaSanPham == ct.MaSanPham
                                                          select sp;
                        Model.SanPham sanpham = cnsp.ElementAtOrDefault(0);
                        sanpham.SoLuongTon = sanpham.SoLuongTon - ct.SoLuong;
                        db.SaveChanges();
                        //xoá chi tiết phiếu
                        db.PhieuNhap_CT.Remove(ct);
                    }
                    int kq = db.SaveChanges();
                    if (kq > 0)
                    {
                        IEnumerable<Model.PhieuNhap> dspn = from pn in db.PhieuNhaps
                                                            where pn.MaPhieuNhap == mapn
                                                            select pn;
                        if (dspn.Count() > 0)
                        {
                            foreach (Model.PhieuNhap pn in dspn)//xoá phiếu
                            {
                                db.PhieuNhaps.Remove(pn);
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
                string MapnThang = "PN" + year.ToString("0000") + month.ToString("00");
                List<Model.PhieuNhap> dspn = (from pn in db.PhieuNhaps
                                              where pn.MaPhieuNhap.Contains(MapnThang)
                                              select pn).ToList();
                if (dspn.Count() > 0)
                {
                    string mangay = dspn.Max(x => x.MaPhieuNhap);
                    int sophieu = Convert.ToInt32(mangay.Substring(8, 6)) + 1;
                    return "PN" + year.ToString("0000") + month.ToString("00") + sophieu.ToString("000000");
                }
                else
                {
                    return "PN" + year.ToString("0000") + month.ToString("00") + "000001";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
