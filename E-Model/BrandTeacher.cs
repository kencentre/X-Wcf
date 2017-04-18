using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace E_Model
{
    [DataContract]
    public class BrandTeacher
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
        /// 导师编号
        /// </summary>		
        private string _teacherid;
        [DataMember]
        public string TEACHERID
        {
            get { return _teacherid; }
            set { _teacherid = value; }
        }

    }
}
