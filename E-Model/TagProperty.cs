using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace E_Model
//Maticsoft.Model
{
    //CMS_TAG_PROPERTY
    [DataContract]
    public class TagProperty
    {

        /// <summary>
        /// 标签编号
        /// </summary>		
        private string _tagid;
        [DataMember]
        public string TAGID
        {
            get { return _tagid; }
            set { _tagid = value; }
        }
        /// <summary>
        /// 属性编号
        /// </summary>		
        private string _propertyid;
        [DataMember]
        public string PROPERTYID
        {
            get { return _propertyid; }
            set { _propertyid = value; }
        }

    }
}

