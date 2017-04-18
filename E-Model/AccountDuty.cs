using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class AccountDuty
    {
        public AccountDuty()
        { }

        #region Model
        private string _accountid;
        private string _dutyid;
        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember]
        public string ACCOUNTID
        {
            set { _accountid = value; }
            get { return _accountid; }
        }
        /// <summary>
        /// 职务编号
        /// </summary>
        [DataMember]
        public string DUTYID
        {
            set { _dutyid = value; }
            get { return _dutyid; }
        }
        #endregion Model
    }
}
