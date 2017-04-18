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
    [ServiceContract(Name = "ICode")]
    public interface ICode
    {
        [OperationContract]
        bool Add(Code model);
        
        [OperationContract]
        Code GetModel(int ID);

        [OperationContract]
        DataSet GetList(string strWhere);

        [OperationContract]
        string CreateCode(int Number);

        [OperationContract]
        DataSet GetTopId();
    }
}
