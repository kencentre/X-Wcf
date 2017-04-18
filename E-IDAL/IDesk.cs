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
    [ServiceContract(Name = "IDesk")]
    public interface IDesk
    {
        [OperationContract]
        bool Add(Desk model);

        [OperationContract]
        bool Update(Desk model);

        [OperationContract]
        bool Delete(string ID);

        [OperationContract]
        bool DeleteList(string IDlist);

        [OperationContract]
        Desk GetModel(string ID);

        [OperationContract]
        DataSet GetList(string strWhere);

        [OperationContract]
        DataSet GetSearchList(string strWhere, string startDate, string endDate);

        [OperationContract]
        Desk ReaderBind(IDataReader dataReader);

        [OperationContract]
        bool UpdateStatus(string ID, decimal Status);
        [OperationContract]
        bool UpdateStatusList(string IDlist);
        [OperationContract]
        DataSet GetUserListByUserID(string ID);
    }
}
