using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class School
    {
        public School()
        { }
        #region Model
        private string _id;
        private string _schoolname;
        private string _schoolename;
        private string _schooladress;
        private string _schoolimage;
        private string _showpicture;
        private string _description;
        private string _status;
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
        /// 校区名称
        /// </summary>
        [DataMember]
        public string SCHOOLNAME
        {
            set { _schoolname = value; }
            get { return _schoolname; }
        }
        /// <summary>
        /// 英文名称
        /// </summary>
        [DataMember]
        public string SCHOOLENAME
        {
            set { _schoolename = value; }
            get { return _schoolename; }
        }
        /// <summary>
        /// 校区地址
        /// </summary>
        [DataMember]
        public string SCHOOLADRESS
        {
            set { _schooladress = value; }
            get { return _schooladress; }
        }
        /// <summary>
        /// 标题图片
        /// </summary>
        [DataMember]
        public string SCHOOLIMAGE
        {
            set { _schoolimage = value; }
            get { return _schoolimage; }
        }
        /// <summary>
        /// 展示图片
        /// </summary>
        [DataMember]
        public string SHOWPICTURE
        {
            set { _showpicture = value; }
            get { return _showpicture; }
        }
        /// <summary>
        /// 校区简介
        /// </summary>
        [DataMember]
        public string DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 校区简介
        /// </summary>
        [DataMember]
        public string STATUS
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
