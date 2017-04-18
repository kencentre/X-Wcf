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
    [ServiceContract(Name = "ILogs")]
    public interface ILogs
    {
        [OperationContract]
        void Add(Logs model);
        
        [OperationContract]
        DataSet GetList(string strWhere);

        [OperationContract]
        DataSet GetSearchList(string strWhere, string startDate, string endDate);
    }
}
