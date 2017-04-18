using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using E_Model;
using System.Data;

namespace E_IDAL
{
    [ServiceContract(Name = "IAccount")]
    public interface IAccount
    {
        [OperationContract]
        bool Add(Account model);

        [OperationContract]
        bool Update(Account model);

        [OperationContract]
        bool Delete(string ID);

        [OperationContract]
        bool DeleteList(string IDlist);

        [OperationContract]
        Account GetModel(string ID);

        [OperationContract]
        DataSet GetList(string strWhere);

        [OperationContract]
        DataSet GetSearchList(string strWhere,string startDate,string endDate);

        [OperationContract]
        Account ReaderBind(IDataReader dataReader);

        [OperationContract]
        bool UpdateStatus(string ID, decimal Status);

        [OperationContract]
        bool UpdateStatusList(string IDlist);

        [OperationContract]
        bool AccountLogin(string UserName,string Password);

        [OperationContract]
        bool UpdatePwd(Account model);

        [OperationContract]
        bool UpdateUserInfo(Account model);

        [OperationContract]
        bool ResetPwd(Account model);

        [OperationContract]
        DataSet GetAccountMainList(string ID);

        [OperationContract]
        DataSet GetAccountMainListByPID(string ID, string ParentID);
    }
}
