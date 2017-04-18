using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class Class
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
        /// 品牌编号
        /// </summary>		
        private string _brandid;
        [DataMember]
        public string BRANDID
        {
            get { return _brandid; }
            set { _brandid = value; }
        }

        /// <summary>
        /// 课程名称
        /// </summary>		
        private string _classname;
        [DataMember]
        public string CLASSNAME
        {
            get { return _classname; }
            set { _classname = value; }
        }
        /// <summary>
        /// 标题图片
        /// </summary>		
        private string _contentpicture;
        [DataMember]
        public string CONTENTPICTURE
        {
            get { return _contentpicture; }
            set { _contentpicture = value; }
        }
        /// <summary>
        /// 内容介绍
        /// </summary>		
        private string _contentbody;
        [DataMember]
        public string CONTENTBODY
        {
            get { return _contentbody; }
            set { _contentbody = value; }
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
