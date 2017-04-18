using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class Brand
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
        /// 品牌名称
        /// </summary>		
        private string _brandname;
        [DataMember]
        public string BRANDNAME
        {
            get { return _brandname; }
            set { _brandname = value; }
        }
        /// <summary>
        /// 英文名称
        /// </summary>		
        private string _brandename;
        [DataMember]
        public string BRANDENAME
        {
            get { return _brandename; }
            set { _brandename = value; }
        }
        /// <summary>
        /// 展示图片
        /// </summary>		
        private string _showpicture;
        [DataMember]
        public string SHOWPICTURE
        {
            get { return _showpicture; }
            set { _showpicture = value; }
        }
        /// <summary>
        /// 标语
        /// </summary>		
        private string _slogan;
        [DataMember]
        public string SLOGAN
        {
            get { return _slogan; }
            set { _slogan = value; }
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
