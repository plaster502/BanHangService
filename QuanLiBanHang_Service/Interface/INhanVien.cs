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
    public interface INhanVien
    {
        [OperationContract]
        [FaultContract(typeof(Exception))]
        string NhanVien_CheckLogIn(string username, string password);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        DataSet NhanVien_GetNhanVien(NhanVien inp, string strsearch);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        NhanVien NhanVien_GetNhanVienByID(string id);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool NhanVien_UpdatePersonalInfo(NhanVien inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool NhanVien_Insert(NhanVien inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool NhanVien_Update(NhanVien inp);

        [OperationContract]
        [FaultContract(typeof(Exception))]
        bool NhanVien_Delete(string manhanvien);

    }
}
