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
    public interface IPhieuNhap
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
        DataSet PhieuNhap_GetPhieuNhap(PhieuNhap inp, string swhere);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        List<PhieuNhapCT> PhieuNhap_LoadChiTiet(string mapn);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool PhieuNhap_Delete(string mapn);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        string PhieuNhap_GetNewID(int year, int month);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool PhieuNhap_Insert(PhieuNhap inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool PhieuNhap_Update(PhieuNhap inp);
    }
}
