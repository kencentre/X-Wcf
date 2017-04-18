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
    [ServiceContract(Name = "IDeskAccount")]
    public interface IDeskAccount
    {
        [OperationContract]
        void Add(DeskAccount model);

        [OperationContract]
        void Delete(string ACCOUNTID);

        [OperationContract]
        DataSet GetList(string strWhere);
        [OperationContract]
        DataSet GetSearchList(string DESKID, string ACCOUNTID);    
    }
}
