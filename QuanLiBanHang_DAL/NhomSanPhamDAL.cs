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
    public class NhomSanPhamDAL
    {
        Model.QuanLiBanHangEntities db = new Model.QuanLiBanHangEntities();
        public List<Model.NhomSanPham> GetData()
        {
            try
            {
                List<Model.NhomSanPham> dsnsp = (from nsp in db.NhomSanPhams
                                                select nsp).ToList();
                return dsnsp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Thêm nhóm sản phẩm
        public bool Insert(NhomSanPham inp)
        {
            try
            {
                Model.NhomSanPham nspnew = new Model.NhomSanPham();
                nspnew.MaNhomSP = inp.MaNhomSanPham;
                nspnew.TenNhomSP = inp.TenNhomSanPham;
                db.NhomSanPhams.Add(nspnew);
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

        //Cập nhật nhóm Sản phẩm
        public bool Update(NhomSanPham inp)
        {
            try
            {
                IEnumerable<Model.NhomSanPham> dsnsp = from nsanpham in db.NhomSanPhams
                                                       where nsanpham.MaNhomSP == inp.MaNhomSanPham
                                                       select nsanpham;
                Model.NhomSanPham nsp = dsnsp.ElementAtOrDefault(0);
                if (nsp != null)
                {
                    nsp.TenNhomSP = inp.TenNhomSanPham;
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

        //Xoá nhóm sản phẩm
        public bool Delete(int mansp)
        {
            try
            {
                IEnumerable<Model.NhomSanPham> dsnsp = from nsanpham in db.NhomSanPhams
                                                       where nsanpham.MaNhomSP == mansp
                                                       select nsanpham;
                if (dsnsp.Count() > 0)
                {
                    foreach (Model.NhomSanPham nsp in dsnsp)
                    {
                        db.NhomSanPhams.Remove(nsp);
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
