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
    [ServiceContract(Name = "IRole")]
    public interface IRole
    {
        [OperationContract]
        bool Add(Role model);

        [OperationContract]
        bool Update(Role model);

        [OperationContract]
        bool Delete(string ID);

        [OperationContract]
        bool DeleteList(string IDlist);

        [OperationContract]
        Role GetModel(string ID);

        [OperationContract]
        DataSet GetList(string strWhere);

        [OperationContract]
        DataSet GetSearchList(string strWhere);

        [OperationContract]
        Role ReaderBind(IDataReader dataReader);

        [OperationContract]
        bool UpdateStatus(string ID, decimal Status);
        [OperationContract]
        bool UpdateStatusList(string IDlist);
    }
}
