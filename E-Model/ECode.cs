using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace E_Model
//Maticsoft.Model
{
    //CMS_CODE
    [DataContract]
    public class ECode
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
        /// CODENAME
        /// </summary>		
        private string _codename;
        [DataMember]
        public string CODENAME
        {
            get { return _codename; }
            set { _codename = value; }
        }
        /// <summary>
        /// CODEIMAGE
        /// </summary>		
        private string _codeimage;
        [DataMember]
        public string CODEIMAGE
        {
            get { return _codeimage; }
            set { _codeimage = value; }
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
        /// DESCRIPTION
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

