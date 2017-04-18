using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class DeskAccount
    {
        public DeskAccount()
        { }

        #region Model
        private string _deskid;
        private string _userid;
        /// <summary>
        /// 桌面编号
        /// </summary>
        [DataMember]
        public string DESKID
        {
            set { _deskid = value; }
            get { return _deskid; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        [DataMember]
        public string USERID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        #endregion Model
    }
}
