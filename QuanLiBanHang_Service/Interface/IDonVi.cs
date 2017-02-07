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
    public interface IDonVi
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
        DonVi DonVi_GetData();

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool DonVi_UpdateInfo(DonVi inp);
    }
}
