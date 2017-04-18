using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class AccountRole
    {
        public AccountRole()
        { }

        #region Model
        private string _accountid;
        private string _roleid;
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
        /// 角色编号
        /// </summary>
        [DataMember]
        public string ROLEID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        #endregion Model
    }
}
