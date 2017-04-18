using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace E_Model
//Maticsoft.Model
{
    //CMS_ABOUT
    [DataContract]
    public class About
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
        /// TITLE
        /// </summary>		
        private string _title;
        [DataMember]
        public string TITLE
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// CHANNEL
        /// </summary>		
        private string _channel;
        [DataMember]
        public string CHANNEL
        {
            get { return _channel; }
            set { _channel = value; }
        }
        /// <summary>
        /// IMAGESHOW
        /// </summary>		
        private string _imageshow;
        [DataMember]
        public string IMAGESHOW
        {
            get { return _imageshow; }
            set { _imageshow = value; }
        }
        /// <summary>
        /// DESCRIPTION
        /// </summary>		
        private string _description;
        [DataMember]
        public string DESCRIPTION
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// STATUS
        /// </summary>		
        private string _status;
        [DataMember]
        public string STATUS
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// CREATEDATE
        /// </summary>		
        private DateTime _createdate;
        [DataMember]
        public DateTime CREATEDATE
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        /// <summary>
        /// CREATEUSER
        /// </summary>		
        private string _createuser;
        [DataMember]
        public string CREATEUSER
        {
            get { return _createuser; }
            set { _createuser = value; }
        }
        /// <summary>
        /// CREATEUSER
        /// </summary>		
        private string _pathurl;
        [DataMember]
        public string PATHURL
        {
            get { return _pathurl; }
            set { _pathurl = value; }
        }
    }
}

