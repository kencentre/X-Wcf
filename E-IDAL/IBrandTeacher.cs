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
    [ServiceContract(Name = "IBrandTeacher")]
    public interface IBrandTeacher
    {
        [OperationContract]
        void Add(BrandTeacher model);

        [OperationContract]
        void Delete(string ID);

        [OperationContract]
        DataSet GetList(string strWhere);
    }
}
