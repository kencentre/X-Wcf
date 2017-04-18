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
    [ServiceContract(Name = "IPropertyValue")]
    public interface IPropertyValue
    {
        [OperationContract]
        bool Add(E_Model.PropertyValue model);

        [OperationContract]
        bool Update(E_Model.PropertyValue model);

        [OperationContract]
        E_Model.PropertyValue GetModel(string ID);

        [OperationContract]
        DataSet GetList(string strWhere);

        [OperationContract]
        E_Model.PropertyValue DataRowToModel(DataRow row);

        [OperationContract]
        E_Model.PropertyValue ReaderBind(IDataReader dataReader);
    }
}
