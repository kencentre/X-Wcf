using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class Account
    {
        public Account()
        { }

        #region Model
        private string _id;
        private string _usercode;
        private string _username;
        private string _passwords;
        private string _dept;
        private string _truename;
        private string _idcard;
        private string _email;
        private string _phone;
        private string _adress;
        private string _description;
        private decimal _status;
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
        /// 工号
        /// </summary>
        [DataMember]
        public string USERCODE
        {
            set { _usercode = value; }
            get { return _usercode; }
        }
        /// <summary>
        /// 帐号
        /// </summary>
        [DataMember]
        public string USERNAME
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        [DataMember]
        public string PASSWORDS
        {
            set { _passwords = value; }
            get { return _passwords; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        [DataMember]
        public string DEPT
        {
            set { _dept = value; }
            get { return _dept; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string TRUENAME
        {
            set { _truename = value; }
            get { return _truename; }
        }
        /// <summary>
        /// 身份证
        /// </summary>
        [DataMember]
        public string IDCARD
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        [DataMember]
        public string EMAIL
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        [DataMember]
        public string PHONE
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        [DataMember]
        public string ADRESS
        {
            set { _adress = value; }
            get { return _adress; }
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
        /// 状态
        /// </summary>
        [DataMember]
        public decimal STATUS
        {
            set { _status = value; }
            get { return _status; }
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
