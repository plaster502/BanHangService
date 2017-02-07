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
    public interface INhomSanPham
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
        List<NhomSanPham> NhomSanPham_GetData();

        [OperationContract]
        [FaultContract(typeof(Exception))]
        List<NhomSanPham> NhomSanPham_Search(string search);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool NhomSanPham_Insert(NhomSanPham inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool NhomSanPham_Update(NhomSanPham inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool NhomSanPham_Delete(int mansp);
    }
}
