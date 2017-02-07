using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using QuanLiBanHang_BDO;

namespace QuanLiBanHang_Service.Interface
{
    [ServiceContract]
    public interface IDonViTinh
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
        List<DonViTinh> DonViTinh_GetData();

        [OperationContract]
        [FaultContract(typeof(Exception))]
        List<DonViTinh> DonViTinh_Search(string search);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool DonViTinh_Insert(DonViTinh inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool DonViTinh_Update(DonViTinh inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool DonViTinh_Delete(int mansp);
    }
}
