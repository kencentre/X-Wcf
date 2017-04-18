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
    [ServiceContract(Name = "ICommon")]
    public interface ICommon
    {
        [OperationContract]
        void ExecuteSql(string Sql);
        
        [OperationContract]
        DataSet GetTableList(string Sql);

        [OperationContract]
        void DeleteTable(string TableName);
    }
}
