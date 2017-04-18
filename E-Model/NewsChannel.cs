using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    public class NewsChannel
    {
        public NewsChannel()
        { }

        #region Model
        private string _id;
        private string _channelname;
        private string _channelcode;
        private string _parentid;
        private string _status;
        private string _description;
        private decimal _sortlist;
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
        /// 栏目名称
        /// </summary>
        [DataMember]
        public string CHANNELNAME
        {
            set { _channelname = value; }
            get { return _channelname; }
        }
        /// <summary>
        /// 栏目编码
        /// </summary>
        [DataMember]
        public string CHANNELCODE
        {
            set { _channelcode = value; }
            get { return _channelcode; }
        }
        /// <summary>
        /// 上级栏目
        /// </summary>
        [DataMember]
        public string PARENTID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 状态（0停用 1启用）
        /// </summary>
        [DataMember]
        public string STATUS
        {
            set { _status = value; }
            get { return _status; }
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

        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public decimal SORTLIST
        {
            set { _sortlist = value; }
            get { return _sortlist; }
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
