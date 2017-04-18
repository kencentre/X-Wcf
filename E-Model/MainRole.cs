using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class MainRole
    {
        public MainRole()
        { }

        #region Model
        private string _mainid;
        private string _roleid;
        /// <summary>
        /// 菜单编号
        /// </summary>
        [DataMember]
        public string MAINID
        {
            set { _mainid = value; }
            get { return _mainid; }
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
