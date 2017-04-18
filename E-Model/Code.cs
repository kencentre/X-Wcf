using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class Code
    {
        public Code()
        { }

        #region Model
        private int _id;
        private int _code;
        /// <summary>
        /// 编号
        /// </summary>
        [DataMember]
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 工号
        /// </summary>
        [DataMember]
        public int CODE
        {
            set { _code = value; }
            get { return _code; }
        }
        #endregion Model
    }
}
