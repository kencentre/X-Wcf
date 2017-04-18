using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace E_IDAL
{
    [ServiceContract(Name = "ISequence")]
    public interface ISequence
    {
        [OperationContract]
        string getSeqId(string SeqName);
    }
}
