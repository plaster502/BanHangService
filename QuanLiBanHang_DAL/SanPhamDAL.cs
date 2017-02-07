using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanHang_BDO;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq.SqlClient;

namespace QuanLiBanHang_DAL
{
    public class SanPhamDAL
    {
        QuanLiBanHang_DAL.Model.QuanLiBanHangEntities db = new QuanLiBanHang_DAL.Model.QuanLiBanHangEntities();
        //Lấy danh sách Sản phẩm
        public List<Model.SanPham> GetSanPham()
        {
            try
            {
                List<Model.SanPham> dssp = (from sanpham in db.SanPhams
                                            select sanpham).ToList();
                return dssp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Thêm sản phẩm
        public bool Insert(SanPham inp)
        {
            try
            {
                Model.SanPham newsp = new Model.SanPham();
                newsp.MaSanPham = inp.MaSanPham;
                newsp.TenSanPham = inp.TenSanPham;
                newsp.MoTa = inp.MoTa;
                newsp.Thue = inp.Thue;
                newsp.DonVi = inp.DonViTinh;
                newsp.NhomSanPham = inp.Nhom;
                newsp.SoLuongTon = 0;

                db.SanPhams.Add(newsp);
                int kq = db.SaveChanges();
                if (kq > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Cập nhật sản phẩm
        public bool Update(SanPham inp)
        {
            try
            {
                IEnumerable<Model.SanPham> dssp = from sanpham in db.SanPhams
                                                  where sanpham.MaSanPham == inp.MaSanPham
                                                  select sanpham;
                Model.SanPham sp = dssp.ElementAtOrDefault(0);
                if (sp != null)
                {
                    sp.TenSanPham = inp.TenSanPham;
                    sp.MoTa = inp.MoTa;
                    sp.Thue = inp.Thue;
                    sp.DonVi = inp.DonViTinh;
                    sp.NhomSanPham = inp.Nhom;
                    int kq = db.SaveChanges();
                    if (kq > 0)
                        return true;
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
        //Xoá sản phẩm
        public bool Delete(string _masp)
        {
            try
            {
                IEnumerable<Model.SanPham> dssp = from sanpham in db.SanPhams
                                                  where sanpham.MaSanPham == _masp
                                                  select sanpham;
                if (dssp.Count() > 0)
                {
                    foreach (Model.SanPham sp in dssp)
                    {
                        db.SanPhams.Remove(sp);
                    }
                    int kq = db.SaveChanges();
                    if (kq > 0)
                        return true;
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

    }
}
