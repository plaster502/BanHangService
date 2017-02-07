using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanHang_BDO;

namespace QuanLiBanHang_DAL
{
    public class NhanNgonNguDAL
    {
        QuanLiBanHang_DAL.Model.QuanLiBanHangEntities db = new QuanLiBanHang_DAL.Model.QuanLiBanHangEntities();
        public string GetLabel(int _mangonngu, int _manhan)
        {
            Model.NhanNgonNgu nhan = (from n in db.NhanNgonNgus
                                      where n.MaNgonNgu == _mangonngu && n.MaNhan == _manhan
                                      select n).FirstOrDefault();
            if (nhan != null)
                return nhan.Chu;
            else
                return "";
        }

        public List<NhanNgonNgu> GetLabelByLang(int _mangonngu)
        {
            List<Model.NhanNgonNgu> nhan = (from n in db.NhanNgonNgus
                                            where n.MaNgonNgu == _mangonngu
                                            select n).ToList();
            if (nhan != null)
            {
                List<NhanNgonNgu> kq = new List<NhanNgonNgu>();
                foreach (Model.NhanNgonNgu lb in nhan)
                {
                    NhanNgonNgu nnn = new NhanNgonNgu();
                    nnn.MaNgonNgu = lb.MaNgonNgu;
                    nnn.MaNhan = lb.MaNhan;
                    nnn.Chu = lb.Chu;
                    kq.Add(nnn);
                }
                return kq;
            }
            else
            {
                return new List<NhanNgonNgu>();
            }
        }
    }
}
