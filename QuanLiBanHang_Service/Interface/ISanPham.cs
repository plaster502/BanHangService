using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLiBanHang_BDO;

namespace QuanLiBanHang_Service.Interface
{
    [ServiceContract]
    public interface ISanPham
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
        List<SanPham> SanPham_GetSanPham(SanPham inp, string strsearch);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        DataSet SanPham_Search(string searchInfo);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool SanPham_Insert(SanPham inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool SanPham_Update(SanPham inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool SanPham_Delete(string masp);
    }
}
