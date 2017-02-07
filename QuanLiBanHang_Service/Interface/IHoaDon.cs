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
    public interface IHoaDon
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
        DataSet HoaDon_GetHoaDon(HoaDon inp, string swhere);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        List<HoaDonCT> HoaDon_LoadChiTiet(string mahd);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool HoaDon_Insert(HoaDon inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool HoaDon_Update(HoaDon inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool HoaDon_Delete(string mahd);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        string HoaDon_GetNewID(int year, int month);
    }
}
