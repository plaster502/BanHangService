using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Data;
using QuanLiBanHang_BDO;

namespace QuanLiBanHang_Service.Interface
{
    [ServiceContract]
    public interface IBaoGia
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
        DataSet BaoGia_GetBaoGia(BaoGia inp, string swhere);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        List<BaoGiaCT> BaoGia_LoadChiTiet(string mabg);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool BaoGia_Insert(BaoGia inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool BaoGia_Update(BaoGia inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool BaoGia_Delete(string mabg);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        string BaoGia_GetNewID(int year, int month);
    }
}
