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
    public class BaoGiaDAL
    {
        QuanLiBanHang_DAL.Model.QuanLiBanHangEntities db = new QuanLiBanHang_DAL.Model.QuanLiBanHangEntities();
        //Lấy danh sách báo giá
        public DataSet GetBaoGia(BaoGia inp, string swhere)
        {
            try
            {
                List<Model.BaoGia> dsbg = (from bg in db.BaoGias
                                              select bg).ToList();
                if (!string.IsNullOrEmpty(inp.MaBaoGia))
                {
                    dsbg = dsbg.Where(baogia => baogia.MaBaoGia == inp.MaBaoGia).ToList();
                }
                if (!string.IsNullOrEmpty(inp.MaNhanVien))
                {
                    dsbg = dsbg.Where(baogia => baogia.NhanVien == inp.MaNhanVien).ToList();
                }
                if (inp.NgayTao.Year != 1)
                {
                    dsbg = dsbg.Where(baogia => baogia.NgayTao == inp.NgayTao).ToList();
                }
                if (inp.NgayHetHan.Year != 1)
                {
                    dsbg = dsbg.Where(baogia => baogia.NgayHetHan == inp.NgayHetHan).ToList();
                }
                if (!string.IsNullOrEmpty(swhere))
                {
                    dsbg = dsbg.Where(baogia => baogia.MaBaoGia.Contains(swhere) || baogia.NhanVien1.TenNhanVien.Contains(swhere) || baogia.NhanVien.Contains(swhere)).ToList();
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("MaBaoGia");
                dt.Columns.Add("NhanVien");
                dt.Columns.Add("TenNhanVien");
                dt.Columns.Add("NgayLap");
                dt.Columns.Add("NgayHetHan");
                dt.Columns.Add("TongTien");
                dt.Columns.Add("ChietKhau");
                if (dsbg.Count > 0)
                {
                    foreach (Model.BaoGia bg in dsbg)
                    {
                        DataRow row = dt.NewRow();
                        row["MaBaoGia"] = bg.MaBaoGia;
                        row["NhanVien"] = bg.NhanVien;
                        row["TenNhanVien"] = bg.NhanVien1.TenNhanVien;
                        row["NgayLap"] = bg.NgayTao;
                        row["NgayHetHan"] = bg.NgayHetHan;
                        row["TongTien"] = bg.TongTien;
                        row["ChietKhau"] = bg.ChietKhau;
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
        //Lấy chi tiết báo giá
        public List<BaoGiaCT> LoadChiTiet(string mabg)
        {
            List<Model.BaoGia_CT> dsct = (from bgct in db.BaoGia_CT
                                          where bgct.MaBaoGia == mabg
                                          select bgct).ToList();
            List<BaoGiaCT> kq = new List<BaoGiaCT>();
            foreach (Model.BaoGia_CT ct in dsct)
            {
                BaoGiaCT kqct = new BaoGiaCT();
                kqct.MaBaoGia = ct.MaBaoGia;
                kqct.MaSanPham = ct.MaSanPham;
                kqct.DonGia = ct.DonGia.Value;
                kqct.SoLuong = ct.SoLuong;
                kq.Add(kqct);
            }
            return kq;
        }

        //Thêm báo giá
        public bool Insert(BaoGia inp)
        {
            try
            {
                Model.BaoGia newbg = new Model.BaoGia();
                newbg.MaBaoGia = inp.MaBaoGia;
                newbg.NhanVien = inp.MaNhanVien;
                newbg.NgayTao = inp.NgayTao;
                newbg.NgayHetHan = inp.NgayHetHan;
                newbg.TongTien = inp.TongTien;
                newbg.ChietKhau = inp.ChietKhau;
                db.BaoGias.Add(newbg);
                int kq = db.SaveChanges();
                if (kq > 0)
                {
                    foreach (BaoGiaCT ct in inp.DSChiTiet)
                    {
                        //Thêm vào chi tiết phiếu nhập
                        Model.BaoGia_CT newct = new Model.BaoGia_CT();
                        newct.MaBaoGia = ct.MaBaoGia;
                        newct.MaSanPham = ct.MaSanPham;
                        newct.SoLuong = ct.SoLuong;
                        newct.DonGia = ct.DonGia;
                        db.BaoGia_CT.Add(newct);
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
        //Sửa báo giá
        public bool Update(BaoGia inp)
        {
            try
            {
                IEnumerable<Model.BaoGia> dsbg = from bg in db.BaoGias
                                                 where bg.MaBaoGia == inp.MaBaoGia
                                                 select bg;
                Model.BaoGia baogia = dsbg.ElementAtOrDefault(0);
                if (baogia != null)
                {
                    baogia.NhanVien = inp.MaNhanVien;
                    baogia.NgayTao = inp.NgayTao;
                    baogia.NgayHetHan = inp.NgayHetHan;
                    baogia.TongTien = inp.TongTien;
                    baogia.ChietKhau = inp.ChietKhau;
                    db.SaveChanges();
                    //Xoá chi tiết báo giá cũ
                    IEnumerable<Model.BaoGia_CT> dsctc = from ctc in db.BaoGia_CT
                                                         where ctc.MaBaoGia == inp.MaBaoGia
                                                         select ctc;
                    if (dsctc.Count() > 0)
                    {
                        foreach (Model.BaoGia_CT ctc in dsctc)
                        {
                            //xoá chi tiết phiếu
                            db.BaoGia_CT.Remove(ctc);
                        }
                        db.SaveChanges();
                    }
                    //Nhập lại chi tiết báo giá
                    foreach (BaoGiaCT ct in inp.DSChiTiet)
                    {
                        Model.BaoGia_CT newct = new Model.BaoGia_CT();
                        newct.MaBaoGia = ct.MaBaoGia;
                        newct.MaSanPham = ct.MaSanPham;
                        newct.SoLuong = ct.SoLuong;
                        newct.DonGia = ct.DonGia;
                        db.BaoGia_CT.Add(newct);
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
        //Xoá báo giá
        public bool Delete(string mabg)
        {
            try
            {
                IEnumerable<Model.BaoGia_CT> dsct = from ct in db.BaoGia_CT
                                                    where ct.MaBaoGia == mabg
                                                    select ct;
                if (dsct.Count() > 0)
                {
                    foreach (Model.BaoGia_CT ct in dsct)//xoá chi tiết
                    {
                        //xoá chi tiết báo giá
                        db.BaoGia_CT.Remove(ct);
                    }
                    int kq = db.SaveChanges();
                    if (kq > 0)//xoá chi tiết báo giá xong mới xoá báo giá
                    {
                        IEnumerable<Model.BaoGia> dsbg = from bg in db.BaoGias
                                                         where bg.MaBaoGia == mabg
                                                         select bg;
                        if (dsbg.Count() > 0)
                        {
                            foreach (Model.BaoGia bg in dsbg)//xoá phiếu
                            {
                                db.BaoGias.Remove(bg);
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

        //Tạo mã báo giá mới
        public string GetNewID(int year, int month)
        {
            try
            {
                string MabgThang = "BG" + year.ToString("0000") + month.ToString("00");
                List<Model.BaoGia> dsbg = (from bg in db.BaoGias
                                           where bg.MaBaoGia.Contains(MabgThang)
                                           select bg).ToList();
                if (dsbg.Count() > 0)
                {
                    string mangay = dsbg.Max(x => x.MaBaoGia);
                    int sophieu = Convert.ToInt32(mangay.Substring(8, 6)) + 1;
                    return "BG" + year.ToString("0000") + month.ToString("00") + sophieu.ToString("000000");
                }
                else
                {
                    return "BG" + year.ToString("0000") + month.ToString("00") + "000001";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
