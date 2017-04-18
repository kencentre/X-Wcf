using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class Student
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
        /// 校区编号
        /// </summary>		
        private string _schoolid;
        [DataMember]
        public string SCHOOLID
        {
            get { return _schoolid; }
            set { _schoolid = value; }
        }
        /// <summary>
        /// 学员名称
        /// </summary>		
        private string _sname;
        [DataMember]
        public string SNAME
        {
            get { return _sname; }
            set { _sname = value; }
        }
        /// <summary>
        /// 英文名称
        /// </summary>		
        private string _ename;
        [DataMember]
        public string ENAME
        {
            get { return _ename; }
            set { _ename = value; }
        }
        /// <summary>
        /// 学员信息
        /// </summary>		
        private string _studentinfo;
        [DataMember]
        public string STUDENTINFO
        {
            get { return _studentinfo; }
            set { _studentinfo = value; }
        }
        /// <summary>
        /// 学员照片
        /// </summary>		
        private string _studentimg;
        [DataMember]
        public string STUDENTIMG
        {
            get { return _studentimg; }
            set { _studentimg = value; }
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
        /// 状态（0 停用 1 启用）
        /// </summary>		
        private string _status;
        [DataMember]
        public string STATUS
        {
            get { return _status; }
            set { _status = value; }
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
