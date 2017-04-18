using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace E_Model
//Maticsoft.Model
{
    //CMS_TAG
    [DataContract]
    public class Tag
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
        /// 标签名称
        /// </summary>		
        private string _tagnaem;
        [DataMember]
        public string TAGNAEM
        {
            get { return _tagnaem; }
            set { _tagnaem = value; }
        }
        /// <summary>
        /// 标签类型
        /// </summary>		
        private string _tagtype;
        [DataMember]
        public string TAGTYPE
        {
            get { return _tagtype; }
            set { _tagtype = value; }
        }
        /// <summary>
        /// 模块名称
        /// </summary>		
        private string _brockid;
        [DataMember]
        public string BROCKID
        {
            get { return _brockid; }
            set { _brockid = value; }
        }
        /// <summary>
        /// 状态（0 停用1 启用）
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

