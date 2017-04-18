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
    [ServiceContract(Name = "ISchool")]
    public interface ISchool
    {
        [OperationContract]
        bool Add(E_Model.School model);

        [OperationContract]
        bool Update(E_Model.School model);

        [OperationContract]
        bool Delete(string ID);

        [OperationContract]
        bool DeleteList(string IDlist);

        E_Model.School GetModel(string ID);

        //E_Model.School DataRowToModel(DataRow row);

        [OperationContract]
        DataSet GetList(string strWhere);

        [OperationContract]
        DataSet GetListByPage(string strWhere, string startDate, string endDate, string startIndex, string endIndex);

        [OperationContract]
        List<E_Model.School> GetListArray(string strWhere);

        [OperationContract]
        E_Model.School ReaderBind(IDataReader dataReader);

        [OperationContract]
        bool UpdateStatus(string ID, string Status);

        [OperationContract]
        bool UpdateStatusList(string IDlist);
    }

}
