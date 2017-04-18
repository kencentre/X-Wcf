using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace E_Model
//Maticsoft.Model
{
    //CMS_WEBSITE
    [DataContract]
    public class WebSite
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
        /// 站点名称
        /// </summary>		
        private string _webname;
        [DataMember]
        public string WEBNAME
        {
            get { return _webname; }
            set { _webname = value; }
        }

        /// <summary>
        /// 站点编码
        /// </summary>		
        private string _webcode;
        [DataMember]
        public string WEBCODE
        {
            get { return _webcode; }
            set { _webcode = value; }
        }
        /// <summary>
        /// 上级编号
        /// </summary>		
        private string _parentid;
        [DataMember]
        public string PARENTID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        /// <summary>
        /// 模版编号
        /// </summary>		
        private string _templateid;
        [DataMember]
        public string TEMPLATEID
        {
            get { return _templateid; }
            set { _templateid = value; }
        }
        /// <summary>
        /// 状态（0 停用  1 启用）
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
        /// 创建时间
        /// </summary>		
        private DateTime _createdate;
        [DataMember]
        public DateTime CREATEDATE
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        /// <summary>
        /// 创建人
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

