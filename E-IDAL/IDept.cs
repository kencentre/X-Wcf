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
    [ServiceContract(Name = "IDept")]
    public interface IDept
    {
        [OperationContract]
        bool Add(Dept model);

        [OperationContract]
        bool Update(Dept model);

        [OperationContract]
        bool Delete(string ID);

        [OperationContract]
        bool DeleteList(string IDlist);

        [OperationContract]
        Dept GetModel(string ID);

        [OperationContract]
        DataSet GetList(string strWhere);

        [OperationContract]
        Dept ReaderBind(IDataReader dataReader);

        [OperationContract]
        DataSet GetAccountListByDeptID(string ID);
    }
}
