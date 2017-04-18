using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class BrandStudent
    {

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
        /// 学员编号
        /// </summary>		
        private string _studentid;
        [DataMember]
        public string STUDENTID
        {
            get { return _studentid; }
            set { _studentid = value; }
        }

    }
}
