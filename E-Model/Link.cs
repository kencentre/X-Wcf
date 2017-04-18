using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace E_Model
//Maticsoft.Model
{
    //CMS_LINK
    [DataContract]
    public class Link
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
        /// LINKENAME
        /// </summary>		
        private string _linkename;
        [DataMember]
        public string LINKENAME
        {
            get { return _linkename; }
            set { _linkename = value; }
        }
        /// <summary>
        /// LINKURL
        /// </summary>		
        private string _linkurl;
        [DataMember]
        public string LINKURL
        {
            get { return _linkurl; }
            set { _linkurl = value; }
        }
        /// <summary>
        /// LINKIMAGE
        /// </summary>		
        private string _linkimage;
        [DataMember]
        public string LINKIMAGE
        {
            get { return _linkimage; }
            set { _linkimage = value; }
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
        /// CREATEDATE
        /// </summary>		
        private DateTime _createdate;
        [DataMember]
        public DateTime CREATEDATE
        {
            get { return _createdate; }
            set { _createdate = value; }
        }

    }
}

