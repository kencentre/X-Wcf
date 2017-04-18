using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class Notice
    {
        public Notice()
        { }

        #region Model
        private string _id;
        private string _title;
        private string _keyword;
        private string _description;
        private string _status;
        private string _annexgroup;
        private DateTime _createdate;
        private string _createuser;
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
        /// 标题
        /// </summary>
        [DataMember]
        public string TITLE
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 关键字
        /// </summary>
        [DataMember]
        public string KEYWORD
        {
            set { _keyword = value; }
            get { return _keyword; }
        }
        /// <summary>
        /// 正文
        /// </summary>
        [DataMember]
        public string DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public string STATUS
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 附件组
        /// </summary>
        [DataMember]
        public string ANNEXGROUP
        {
            set { _annexgroup = value; }
            get { return _annexgroup; }
        }
        /// <summary>
        /// 创建时间
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
        #endregion Model
    }
}
