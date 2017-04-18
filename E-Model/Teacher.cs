using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class Teacher
    {

        /// <summary>
        /// ID
        /// </summary>		
        private string _id;
        [DataMember]
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 中文名称
        /// </summary>		
        private string _chnname;
        [DataMember]
        public string CHNNAME
        {
            get { return _chnname; }
            set { _chnname = value; }
        }
        /// <summary>
        /// 英文名称
        /// </summary>		
        private string _engname;
        [DataMember]
        public string ENGNAME
        {
            get { return _engname; }
            set { _engname = value; }
        }
        /// <summary>
        /// 头衔
        /// </summary>		
        private string _rank;
        [DataMember]
        public string RANK
        {
            get { return _rank; }
            set { _rank = value; }
        }
        /// <summary>
        /// 照片
        /// </summary>		
        private string _tpicture;
        [DataMember]
        public string TPICTURE
        {
            get { return _tpicture; }
            set { _tpicture = value; }
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
