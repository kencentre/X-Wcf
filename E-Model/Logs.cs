using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class Logs
    {
        public Logs()
        { }

        #region Model
        private string _id;
        private DateTime _createdate;
        private string _createuser;
        private string _eventcode;
        private string _eventtype;
        private string _description;
        /// <summary>
        /// 编号
        /// </summary>
        [DataMember]
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        public DateTime CREATEDATE
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public string CREATEUSER
        {
            set { _createuser = value; }
            get { return _createuser; }
        }
        /// <summary>
        /// 日志代码
        /// </summary>
        [DataMember]
        public string EVENTCODE
        {
            set { _eventcode = value; }
            get { return _eventcode; }
        }
        /// <summary>
        /// 时间类型
        /// </summary>
        [DataMember]
        public string EVENTTYPE
        {
            set { _eventtype = value; }
            get { return _eventtype; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
        }
        #endregion Model
    }
}
