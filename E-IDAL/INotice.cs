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
    [ServiceContract(Name = "INotice")]
    public interface INotice
    {
        [OperationContract]
        bool Add(Notice model);

        [OperationContract]
        bool Update(Notice model);

        [OperationContract]
        bool Delete(string ID);

        [OperationContract]
        bool DeleteList(string IDlist);

        [OperationContract]
        Notice GetModel(string ID);

        [OperationContract]
        DataSet GetList(string strWhere);

        [OperationContract]
        DataSet GetSearchList(string strWhere, string startDate, string endDate);

        [OperationContract]
        Notice ReaderBind(IDataReader dataReader);

        [OperationContract]
        bool UpdateStatus(string ID, decimal Status);

        [OperationContract]
        bool UpdateStatusList(string IDlist);

        [OperationContract]
        DataSet GetTopList(string strWhere,int rowNum);

    }
}
