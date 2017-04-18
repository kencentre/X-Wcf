using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace E_Model
//DAL.Model
{
    //CMS_TEMPLATE
    [DataContract]
    public class Template
    {

        /// <summary>
        /// 编号
        /// </summary>		
        private string _id;
        [DataMember]
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 模版名称
        /// </summary>		
        private string _templatename;
        [DataMember]
        public string TEMPLATENAME
        {
            get { return _templatename; }
            set { _templatename = value; }
        }
        /// <summary>
        /// 模版地址
        /// </summary>		
        private string _templateurl;
        [DataMember]
        public string TEMPLATEURL
        {
            get { return _templateurl; }
            set { _templateurl = value; }
        }
        /// <summary>
        /// 状态（0 停用 1发布）
        /// </summary>		
        private string _status;
        [DataMember]
        public string STATUS
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>		
        private string _description;
        [DataMember]
        public string DESCRIPTION
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>		
        private DateTime _createdate;
        [DataMember]
        public DateTime CREATEDATE
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        /// <summary>
        /// 发布人
        /// </summary>		
        private string _createuser;
        [DataMember]
        public string CREATEUSER
        {
            get { return _createuser; }
            set { _createuser = value; }
        }

    }
}

