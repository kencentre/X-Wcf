using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace E_Model
//DAL.Model
{
    //CMS_SIGNUP_BRAND
    [DataContract]
    public class SignupBrand
    {

        /// <summary>
        /// 报名编号
        /// </summary>		
        private string _signuoid;
        [DataMember]
        public string SIGNUOID
        {
            get { return _signuoid; }
            set { _signuoid = value; }
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

    }
}

