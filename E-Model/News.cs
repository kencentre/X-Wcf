using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace E_Model
{
    //CMS_NEWS
    [DataContract]
    public class News
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
        /// 标题
        /// </summary>		
        private string _title;
        [DataMember]
        public string TITLE
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// 关键字
        /// </summary>		
        private string _keywords;
        [DataMember]
        public string KEYWORDS
        {
            get { return _keywords; }
            set { _keywords = value; }
        }
        /// <summary>
        /// 栏目
        /// </summary>		
        private string _channel;
        [DataMember]
        public string CHANNEL
        {
            get { return _channel; }
            set { _channel = value; }
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
        /// 缩略图
        /// </summary>		
        private string _imageshow;
        [DataMember]
        public string IMAGESHOW
        {
            get { return _imageshow; }
            set { _imageshow = value; }
        }
        /// <summary>
        /// 正文
        /// </summary>		
        private string _newstext;
        [DataMember]
        public string NEWSTEXT
        {
            get { return _newstext; }
            set { _newstext = value; }
        }
        /// <summary>
        /// 静态地址
        /// </summary>		
        private string _newsurl;
        [DataMember]
        public string NEWSURL
        {
            get { return _newsurl; }
            set { _newsurl = value; }
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
        /// <summary>
        /// 发布人
        /// </summary>		
        private string _videoshow;
        [DataMember]
        public string VIDEOSHOW
        {
            get { return _videoshow; }
            set { _videoshow = value; }
        }
    }
}

