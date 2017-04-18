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
    [ServiceContract(Name = "IDictionary")]
    public interface IDictionary
    {
        [OperationContract]
        bool Add(Dictionary model);

        [OperationContract]
        bool Update(Dictionary model);

        [OperationContract]
        bool Delete(string ID);

        [OperationContract]
        bool DeleteList(string IDlist);

        [OperationContract]
        Dictionary GetModel(string ID);

        [OperationContract]
        DataSet GetList(string strWhere);

        [OperationContract]
        Dictionary ReaderBind(IDataReader dataReader);

        [OperationContract]
        DataSet GetSearchList(string strWhere, string startDate, string endDate);

        [OperationContract]
        DataSet GetParentList(string strWhere);
    }
}
