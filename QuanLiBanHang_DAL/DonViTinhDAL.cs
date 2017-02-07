using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanHang_BDO;
namespace QuanLiBanHang_DAL
{
    public class DonViTinhDAL
    {
        Model.QuanLiBanHangEntities db = new Model.QuanLiBanHangEntities();
        public List<Model.DonViTinh> GetData()
        {
            try
            {
                List<Model.DonViTinh> dsdvt = (from dvt in db.DonViTinhs
                                                 select dvt).ToList();
                db.Dispose();
                return dsdvt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Thêm đơn vị tính
        public bool Insert(DonViTinh inp)
        {
            try
            {
                Model.DonViTinh dvtnew = new Model.DonViTinh();
                dvtnew.MaDonViTinh = inp.MaDonViTinh;
                dvtnew.TenDonViTinh = inp.TenDonViTinh;
                db.DonViTinhs.Add(dvtnew);
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

        //Cập nhật đơn vị tính
        public bool Update(DonViTinh inp)
        {
            try
            {
                IEnumerable<Model.DonViTinh> dsdvt = from dvt in db.DonViTinhs
                                                     where dvt.MaDonViTinh == inp.MaDonViTinh
                                                     select dvt;
                Model.DonViTinh donvitinh = dsdvt.ElementAtOrDefault(0);
                if (donvitinh != null)
                {
                    donvitinh.TenDonViTinh = inp.TenDonViTinh;
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

        //Xoá nhóm đơn vị tính
        public bool Delete(int madvt)
        {
            try
            {
                IQueryable<Model.DonViTinh> dsdvt = from dvt in db.DonViTinhs
                                                     where dvt.MaDonViTinh == madvt
                                                     select dvt;
                if (dsdvt.Count() > 0)
                {
                    foreach (Model.DonViTinh donvitinh in dsdvt)
                    {
                        db.DonViTinhs.Remove(donvitinh);
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
