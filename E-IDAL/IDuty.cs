using E_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace E_IDAL
{
    [ServiceContract(Name = "IDuty")]
    public interface IDuty
    {
        [OperationContract]
        bool Add(Duty model);

        [OperationContract]
        bool Update(Duty model);

        [OperationContract]
        bool Delete(string ID);

        [OperationContract]
        bool DeleteList(string IDlist);

        [OperationContract]
        Duty GetModel(string ID);

        [OperationContract]
        DataSet GetList(string strWhere);

        [OperationContract]
        DataSet GetSearchList(string strWhere);

        [OperationContract]
        Duty ReaderBind(IDataReader dataReader);

        [OperationContract]
        bool UpdateStatus(string ID, decimal Status);
        [OperationContract]
        bool UpdateStatusList(string IDlist);
        [OperationContract]
        DataSet GetUserListByDutyID(string ID);
    }
}
