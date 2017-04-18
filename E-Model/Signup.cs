using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace E_Model
{
    //CMS_SIGNUP
    [DataContract]
    public class Signup
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
        /// 姓名
        /// </summary>		
        private string _username;
        [DataMember]
        public string USERNAME
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// 学校
        /// </summary>		
        private string _schoolid;
        [DataMember]
        public string SCHOOLID
        {
            get { return _schoolid; }
            set { _schoolid = value; }
        }
        /// <summary>
        /// 电话
        /// </summary>		
        private string _phone;
        [DataMember]
        public string PHONE
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// QQ
        /// </summary>		
        private string _qq;
        [DataMember]
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>		
        private string _email;
        [DataMember]
        public string EMAIL
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// 联系地址
        /// </summary>		
        private string _adress;
        [DataMember]
        public string ADRESS
        {
            get { return _adress; }
            set { _adress = value; }
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
        /// 报名时间
        /// </summary>		
        private DateTime _createdate;
        [DataMember]
        public DateTime CREATEDATE
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>		
        private string _status;
        [DataMember]
        public string STATUS
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}

