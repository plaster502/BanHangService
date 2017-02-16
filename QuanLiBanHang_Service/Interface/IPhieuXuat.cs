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
    public interface IPhieuXuat
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
        DataSet PhieuXuat_GetPhieuXuat(PhieuXuat inp, string swhere);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        List<PhieuXuatCT> PhieuXuat_LoadChiTiet(string mapx);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool PhieuXuat_Insert(PhieuXuat inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool PhieuXuat_Update(PhieuXuat inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool PhieuXuat_Delete(string mapx);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        string PhieuXuat_GetNewID(int year, int month);
    }
}
