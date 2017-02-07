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
    public class NhomSanPhamBUS
    {
        private NhomSanPhamDAL dal = new NhomSanPhamDAL();

        //Lấy thông tin nhóm sản phẩm
        public List<NhomSanPham> GetData()
        {
            List<QuanLiBanHang_DAL.Model.NhomSanPham> dsnsp = dal.GetData();
            QuanLiBanHang_DAL.Model.NhomSanPham macdinh = new QuanLiBanHang_DAL.Model.NhomSanPham
            {
                MaNhomSP = 0,
                TenNhomSP = "-----------Chọn------------"
            };
            dsnsp.Insert(0, macdinh);

            List<NhomSanPham> kq = new List<NhomSanPham>();
            if (dsnsp.Count > 0)
            {
                foreach (QuanLiBanHang_DAL.Model.NhomSanPham nsp in dsnsp)
                {
                    NhomSanPham add = new NhomSanPham
                    {
                        MaNhomSanPham = nsp.MaNhomSP,
                        TenNhomSanPham = nsp.TenNhomSP
                    };
                    kq.Add(add);
                }
            }
            return kq;
        }
        //Tìm kiếm 
        public List<NhomSanPham> Search(string search)
        {
            List<QuanLiBanHang_DAL.Model.NhomSanPham> dsnsp = dal.GetData();
            if (!string.IsNullOrEmpty(search))
            {
                dsnsp = dsnsp.Where(nsanpham => nsanpham.TenNhomSP.ToLower().Contains(search.ToLower())).ToList();
            }

            List<NhomSanPham> kq = new List<NhomSanPham>();
            if (dsnsp.Count > 0)
            {
                foreach (QuanLiBanHang_DAL.Model.NhomSanPham nsp in dsnsp)
                {
                    NhomSanPham add = new NhomSanPham
                    {
                        MaNhomSanPham = nsp.MaNhomSP,
                        TenNhomSanPham = nsp.TenNhomSP
                    };
                    kq.Add(add);
                }
            }
            return kq;
        }

        public bool Insert(NhomSanPham inp)
        {
            return dal.Insert(inp);
        }

        public bool Update(NhomSanPham inp)
        {
            return dal.Update(inp);
        }

        public bool Delete(int mansp)
        {
            return dal.Delete(mansp);
        }
    }
}
