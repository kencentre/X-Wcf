using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace E_Model
//Maticsoft.Model
{
    //CMS_PROPERTY_VALUE
    [DataContract]
    public class PropertyValue
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
        /// <summary>
        /// 属性值
        /// </summary>		
        private string _propertyvalue;
        [DataMember]
        public string PROPERTYVALUE
        {
            get { return _propertyvalue; }
            set { _propertyvalue = value; }
        }

    }
}

