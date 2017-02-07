using System;
using System.ServiceModel;
using System.Collections.Generic;
using QuanLiBanHang_BDO;

namespace QuanLiBanHang_Service.Interface
{
    [ServiceContract]
    public interface INhanNgonNgu
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
        string NhanNgonNgu_GetLabel(int _mangonngu, int _manhan);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        List<NhanNgonNgu> NhanNgonNgu_GetLabelByLang(int _mangonngu);
    }
}
