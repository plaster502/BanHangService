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
    public interface IDonDatHang
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
        DataSet DonDatHang_GetDonHang(DonDatHang inp, string swhere);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        List<DonDatHangCT> DonDatHang_LoadChiTiet(string madh);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool DonDatHang_Insert(DonDatHang inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool DonDatHang_Update(DonDatHang inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool DonDatHang_Delete(string madh);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        string DonDatHang_GetNewID(int year, int month);
    }
}
