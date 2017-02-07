using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanHang_DAL;
using QuanLiBanHang_BDO;
using System.Data;

namespace QuanLiBanHang_BUS
{
    public class DonViTinhBUS
    {
        private DonViTinhDAL dal = new DonViTinhDAL();

        //Lấy thông tin đơn vị tính
        public List<DonViTinh> GetData()
        {
            List<QuanLiBanHang_DAL.Model.DonViTinh> dsdvt = dal.GetData();

            QuanLiBanHang_DAL.Model.DonViTinh macdinh = new QuanLiBanHang_DAL.Model.DonViTinh
            {
                MaDonViTinh = 0,
                TenDonViTinh = "-----------Chọn------------"
            };
            dsdvt.Insert(0, macdinh);

            List<DonViTinh> kq = new List<DonViTinh>();
            if (dsdvt.Count > 0)
            {
                foreach (QuanLiBanHang_DAL.Model.DonViTinh dvt in dsdvt)
                {
                    DonViTinh add = new DonViTinh
                    {
                        MaDonViTinh = dvt.MaDonViTinh,
                        TenDonViTinh = dvt.TenDonViTinh
                    };
                    kq.Add(add);
                }
            }
            return kq;
        }
        //Tìm kiếm 
        public List<DonViTinh> Search(string search)
        {
            List<QuanLiBanHang_DAL.Model.DonViTinh> dsdvt = dal.GetData();
            if (!string.IsNullOrEmpty(search))
            {
                dsdvt = dsdvt.Where(donvitinh => donvitinh.TenDonViTinh.ToLower().Contains(search.ToLower())).ToList();
            }

            List<DonViTinh> kq = new List<DonViTinh>();
            if (dsdvt.Count > 0)
            {
                foreach (QuanLiBanHang_DAL.Model.DonViTinh dvt in dsdvt)
                {
                    DonViTinh add = new DonViTinh
                    {
                        MaDonViTinh = dvt.MaDonViTinh,
                        TenDonViTinh = dvt.TenDonViTinh
                    };
                    kq.Add(add);
                }
            }
            return kq;
        }

        public bool Insert(DonViTinh inp)
        {
            return dal.Insert(inp);
        }

        public bool Update(DonViTinh inp)
        {
            return dal.Update(inp);
        }

        public bool Delete(int mansp)
        {
            return dal.Delete(mansp);
        }
    }
}
