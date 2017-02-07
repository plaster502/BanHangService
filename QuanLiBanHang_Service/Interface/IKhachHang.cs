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
    public interface IKhachHang
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
        DataSet KhachHang_GetKhachHang(KhachHang inp, string swhere);
    }
}
